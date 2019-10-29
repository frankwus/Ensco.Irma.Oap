using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Models.Domain.Workflow;
using System;
using System.Activities;
using System.Linq;

namespace Ensco.Irma.Services.Workflow.Activity
{
    public class RigChecklistVerifiersReject : RigChecklistBaseActivity
    {
        [RequiredArgument]
        public InArgument<RejectionRequest> Reject { get; set; }

       

        protected override void Execute(NativeActivityContext context)
        {
            base.Execute(context);
             
            var request = Reject.Get(context); 

            RigOapChecklistVerifier rigOapVerifier = null;

            if  (request.Inputs.TryGetValue("Verifier", out object verifierId))
            {
                rigOapVerifier = RigChecklist.VerifiedBy.FirstOrDefault(c => c.UserId == (int) verifierId);

                if (rigOapVerifier == null)
                {
                    return;
                }
            }

            UpdateTask(rigOapVerifier, RigChecklist.RigChecklistUniqueId, WorkflowStatus.Completed.ToString());

            rigOapVerifier.SignedOn = DateTime.UtcNow;

            rigOapVerifier.Status = WorkflowStatus.Rejected.ToString();

            rigOapVerifier.Comment = request.Reason;

            RigChecklist.Status = ChecklistStatus.Completed.ToString();

            RigChecklistService.Save(RigChecklist); 
        }
    }

}
