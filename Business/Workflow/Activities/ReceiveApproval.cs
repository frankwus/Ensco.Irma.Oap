using System.Activities;
using Ensco.Irma.Models.Domain.Workflow;

namespace Ensco.Irma.Business.Workflow.Activities
{
    [DefaultRequestVerb("Approve")]
    public class ReceiveApproval : ReceiveRequest<ApprovalRequest>
    {
        protected override WorkflowTransition CreateWorkflowTransition(NativeActivityContext context, string bookmarkName, string requiredPermission)
        {
            return new ApprovalTransition(bookmarkName, requiredPermission);
        }
    }
}
