
namespace Ensco.Irma.Models.Domain.Workflow
{
    public class AssignmentTransition : WorkflowTransition
    {
        public AssignmentTransition(string name, string requiredPermission = null)
            : base(name, requiredPermission)
        {

        }

        public AssignmentTransition()
            : base()
        {

        }

        public bool PromptForPeople { get; set; }

        public string PromptFilter { get; set; }

    }
}