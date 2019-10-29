
namespace Ensco.Irma.Models.Domain.Workflow
{
    public class ApprovalTransition : WorkflowTransition
    {
        public ApprovalTransition(string name, string requiredPermission = null)
            : base(name, requiredPermission)
        {

        }

        public ApprovalTransition()
            : base()
        {

        }

    }
}
