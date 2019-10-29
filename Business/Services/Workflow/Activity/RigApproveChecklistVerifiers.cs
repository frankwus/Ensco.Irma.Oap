using Ensco.Irma.Models.Domain.Workflow;
using System;
using System.Activities;
using System.Linq;

namespace Ensco.Irma.Services.Workflow.Activity
{
    public class RigApproveChecklistVerifiers : RigChecklistBaseActivity
    {
        [RequiredArgument]
        public InArgument<AssignmentRequest> Verifier { get; set; }

        [RequiredArgument]
        public OutArgument<bool> AllVerifiersApproved { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            base.Execute(context);

            const string CompletedStatus = "Completed";
            const string PendingStatus = "Pending";

            var verifier = Verifier.Get(context);

            var rigOapVerifier = RigChecklist.VerifiedBy.FirstOrDefault(c => c.UserId == verifier.Id);

            if (rigOapVerifier == null)
            {
                return;
            }

            rigOapVerifier.SignedOn = DateTime.UtcNow;

            rigOapVerifier.Status = CompletedStatus;

            if (RigChecklist.VerifiedBy.Any(v => !v.Status.Equals(CompletedStatus)))
            {
                var pendingVerifier = RigChecklist.VerifiedBy.FirstOrDefault(v => v.Order == (rigOapVerifier.Order + 1));

                if (pendingVerifier == null)
                {
                    throw new Exception("Verifier Order Status are invalid");
                }

                pendingVerifier.Status = PendingStatus;
                RigChecklistService.Save(RigChecklist);
                return;
            }

            RigChecklistService.Save(RigChecklist);

            AllVerifiersApproved.Set(context, true);
        }
    }

}
