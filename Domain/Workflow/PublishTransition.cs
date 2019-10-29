
namespace Ensco.Irma.Models.Domain.Workflow
{
    public class PublishTransition : WorkflowTransition
    {
        public PublishTransition(string name, string requiredPermission = null)
            : base(name, requiredPermission)
        {

        }

        public PublishTransition()
            : base()
        {

        }

    }
}