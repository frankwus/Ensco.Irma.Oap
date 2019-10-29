
namespace Ensco.Irma.Models.Domain.Workflow
{
    public class RejectionTransition : WorkflowTransition
    {
        public RejectionTransition(string name, string requiredPermission = null)
            : base(name, requiredPermission)
        {

        }

        public RejectionTransition()
            : base()
        {

        }

    }
}