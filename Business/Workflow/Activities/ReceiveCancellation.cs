using Ensco.Irma.Models.Domain.Workflow;
using System.Activities; 
namespace Ensco.Irma.Business.Workflow.Activities
{
    [DefaultRequestVerb("Cancel")]
    public class ReceiveCancellation : ReceiveRequest<CancellationRequest>
    {
        protected override WorkflowTransition CreateWorkflowTransition(NativeActivityContext context, string bookmarkName, string requiredPermission)
        {
            return new CancellationTransition(bookmarkName, requiredPermission);
        }
    }
}
