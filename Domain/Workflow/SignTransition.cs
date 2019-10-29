
namespace Ensco.Irma.Models.Domain.Workflow
{
    public class SignTransition : WorkflowTransition
    {
        public SignTransition(string name, string requiredPermission = null)
            : base(name, requiredPermission)
        {

        }

        public SignTransition()
            : base()
        {

        }

    }
}
