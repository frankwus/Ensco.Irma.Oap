using System.Activities;
using Ensco.Irma.Models.Domain.Workflow;

namespace Ensco.Irma.Business.Workflow.Activities
{
    [DefaultRequestVerb("Sign")]
    public class ReceiveSign : ReceiveRequest<SignRequest>
    {
        protected override WorkflowTransition CreateWorkflowTransition(NativeActivityContext context, string bookmarkName, string requiredPermission)
        {
            return new SignTransition(bookmarkName, requiredPermission);
        }
    }
}
