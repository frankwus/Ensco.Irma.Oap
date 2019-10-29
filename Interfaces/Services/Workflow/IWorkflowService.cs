using workflow = Ensco.Irma.Models.Domain.Workflow;

namespace Ensco.Irma.Interfaces.Services.Workflow
{
    public interface IWorkflowService : IEntityService<workflow.Workflow, int>
    {
        workflow.Workflow GetActiveWorkflow(int rigChecklistId);
    }
}
