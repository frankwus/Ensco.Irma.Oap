
namespace Ensco.Irma.Models.Domain.Workflow
{
    public class ReceiveTransition : WorkflowTransition
    {
        public ReceiveTransition(string name, string requiredPermission = null)
            : base(name, requiredPermission)
        {

        }

        public ReceiveTransition()
            : base()
        {

        }

    }
}