using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Models.Domain.Workflow;
using System;
using System.Activities;
using System.Linq;

namespace Ensco.Irma.Services.Workflow.Activity
{
    public class RigChecklistVerifiersSign : RigChecklistBaseActivity
    {
        [RequiredArgument]
        public InArgument<SignRequest> Sign { get; set; }

        [RequiredArgument]
        public OutArgument<bool> AllVerifiersSigned { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            base.Execute(context);

            var request = Sign.Get(context);

            
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

            rigOapVerifier.Status = WorkflowStatus.Completed.ToString();
             
            if (RigChecklist.VerifiedBy.Any(v => !v.isReviewer && string.IsNullOrEmpty(v.Status)))
            {
                var pendingNonReviewer = RigChecklist.VerifiedBy.Where(v => !v.isReviewer && string.IsNullOrEmpty(v.Status)).OrderBy(v => v.Order).FirstOrDefault();

                if (pendingNonReviewer == null)
                {
                    return;
                }

                AddTask(pendingNonReviewer, RigChecklist.RigChecklistUniqueId, $"Waiting for {pendingNonReviewer.Role}, {pendingNonReviewer.User?.Name} to sign", "Open");

                pendingNonReviewer.Status = WorkflowStatus.Pending.ToString();
                RigChecklistService.Save(RigChecklist);
                return;
            }


            if (RigChecklist.VerifiedBy.Any(v => v.isReviewer && string.IsNullOrEmpty(v.Status)))
            {
                var pendingReviewer = RigChecklist.VerifiedBy.Where(v => v.isReviewer && string.IsNullOrEmpty(v.Status)).OrderBy(v => v.Order).FirstOrDefault();

                if (pendingReviewer == null)
                {
                    return;
                }

                AddTask(pendingReviewer, RigChecklist.RigChecklistUniqueId, $"Waiting for {pendingReviewer.Role}, {pendingReviewer.User?.Name} to review", "Open");

                pendingReviewer.Status = WorkflowStatus.Pending.ToString();
                RigChecklistService.Save(RigChecklist);
            } 

            AllVerifiersSigned.Set(context, true);
        }

        
    }

}
