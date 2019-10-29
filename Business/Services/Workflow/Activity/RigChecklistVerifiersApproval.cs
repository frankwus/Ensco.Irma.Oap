using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Models.Domain.Workflow;
using System;
using System.Activities;
using System.Linq;

namespace Ensco.Irma.Services.Workflow.Activity
{
    public class RigChecklistVerifiersApproval : RigChecklistBaseActivity
    {
        [RequiredArgument]
        public InArgument<ApprovalRequest> Approval { get; set; }

        [RequiredArgument]
        public OutArgument<bool> AllVerifiersApproved { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            base.Execute(context);

            var request = Approval.Get(context);

            RigOapChecklistVerifier rigOapVerifier = null;

            if  (request.Inputs.TryGetValue("Verifier", out object verifierId))
            {
                rigOapVerifier = RigChecklist.VerifiedBy.FirstOrDefault(c => c.isReviewer && c.UserId == (int) verifierId);
            } 

            if (rigOapVerifier == null)
            {
                return;
            }

            rigOapVerifier.SignedOn = DateTime.UtcNow;

            rigOapVerifier.Status = WorkflowStatus.Completed.ToString();

            UpdateTask(rigOapVerifier, RigChecklist.RigChecklistUniqueId, WorkflowStatus.Completed.ToString());


            if (RigChecklist.VerifiedBy.Any(v => v.isReviewer && !v.Status.Equals(WorkflowStatus.Completed.ToString())))
            {
                var pendingReviewer = RigChecklist.VerifiedBy.OrderBy(v => v.Order).FirstOrDefault(v => v.isReviewer && !v.Status.Equals(WorkflowStatus.Completed.ToString()));

                if (pendingReviewer == null)
                {
                    throw new Exception("Verifier Order Status are invalid");
                }

                AddTask(pendingReviewer, RigChecklist.RigChecklistUniqueId, $"Waiting for {pendingReviewer.Role}, {pendingReviewer.User?.Name} to review", "Open");

                pendingReviewer.Status = WorkflowStatus.Pending.ToString();
            }
            else //All Reviewers and OIM Verified
            {
                RigChecklist.Status = ChecklistStatus.Completed.ToString();
                AllVerifiersApproved.Set(context, true);
            }

            RigChecklistService.Save(RigChecklist);

            
        }
    }

}
