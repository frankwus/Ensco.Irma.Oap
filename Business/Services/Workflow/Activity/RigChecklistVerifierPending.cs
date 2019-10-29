using Ensco.Irma.Framework.Configuration;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Models.Domain.Workflow;
using System;
using System.Activities;
using System.Linq;

namespace Ensco.Irma.Services.Workflow.Activity
{
    public class RigChecklistVerifierPending : RigChecklistBaseActivity
    {
        protected override void Execute(NativeActivityContext context)
        {
            base.Execute(context);

            var rigOapVerifier = RigChecklist.VerifiedBy.FirstOrDefault(c => !c.isReviewer && string.IsNullOrEmpty(c.Status));

            if (rigOapVerifier == null)
            {
                return;
            }

            AddTask(rigOapVerifier, RigChecklist.RigChecklistUniqueId, $"Waiting for {rigOapVerifier.Role}, {rigOapVerifier.User?.Name} to sign", "Open");


            rigOapVerifier.Status = WorkflowStatus.Pending.ToString(); 

            RigChecklistService.Save(RigChecklist);
        }
    }

}
