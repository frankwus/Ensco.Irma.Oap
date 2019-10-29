
namespace Ensco.Irma.Models.Domain.Workflow
{
    public class CancellationTransition : WorkflowTransition
    {
        public CancellationTransition(string name, string requiredPermission = null)
            : base(name, requiredPermission)
        {

        }

        public CancellationTransition()
            : base()
        {

        }

    }
}