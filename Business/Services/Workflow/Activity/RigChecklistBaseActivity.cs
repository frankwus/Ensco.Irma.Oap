using Ensco.Irma.Data.Context;
using Ensco.Irma.Data.Repositories;
using Ensco.Irma.Framework.Configuration;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Interfaces.Services;
using Ensco.Irma.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Services.Oap;
using SimpleInjector;
using System;
using System.Activities;
using System.Linq;
using Ensco.Irma.Services.Irma;
using Ensco.Irma.Interfaces.Services.Security;

namespace Ensco.Irma.Services.Workflow.Activity
{
    public class RigChecklistBaseActivity : NativeActivity
    {
        public RigChecklistBaseActivity():base()
        {
            
        }

        [RequiredArgument]
        public InArgument<Guid> RigOapChecklistId { get; set; }

        protected Container Container { get; } = FrameworkEnvironment.Instance.Container;

        protected IRigOapChecklistService RigChecklistService { get; set; }

        protected IIrmaTaskService IrmaTaskService { get; set; }

        protected IPeopleService peopleService { get; set; }

        protected RigOapChecklist  RigChecklist { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            var rigChecklistId = RigOapChecklistId.Get(context);

            try
            {
                RigChecklistService = Container.GetInstance<IRigOapChecklistService>();
                IrmaTaskService = Container.GetInstance<IIrmaTaskService>();
                peopleService = Container.GetInstance<IPeopleService>();
            }
            catch (Exception ex)
            {
                //TODO :  Add error logging
            }

            RigChecklist = RigChecklistService.Get(rigChecklistId);
        }

        protected void AddTask(RigOapChecklistVerifier verifier, int rigChecklistId, string comment, string status)
        {

            IrmaTaskService.Add(new Models.Domain.IRMA.IrmaTask
            {
                Source = "Oap - Workflow",
                SourceId = rigChecklistId.ToString(),
                AssigneeId = verifier.UserId,
                AssignedDateTime = DateTime.UtcNow,
                Comment = comment,
                AssignedBy = verifier.UserId,
                Status = status
            });

            if (status.Equals("Open"))
            {
                var reviewStatus = verifier.Role.Equals(VerifierRole.Assessor.ToString(), StringComparison.InvariantCultureIgnoreCase) ? "signing" : "review";
                SendEmail(verifier.UserId, "Rig Checklist Verfication", $"You have been assigned to checklist {RigChecklist.RigChecklistUniqueId} for {reviewStatus}.");
            }
        }

        protected int SendEmail(int userId, string subject, string body)
        {
            var user = peopleService.Get(userId);

            return IrmaTaskService.SendEmail(user.Email, subject, body);
        }


        protected void UpdateTask(RigOapChecklistVerifier verifier, int rigChecklistId, string status)
        {
            var task = IrmaTaskService.GetBySourceAssignee("Oap - Workflow",rigChecklistId, verifier.UserId);
            if (task != null)
            {
                task.Status = status;
                IrmaTaskService.Update(task);
            }
        }
    }

}
