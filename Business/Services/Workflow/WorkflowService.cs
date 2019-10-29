using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Services.Workflow;
using workflow = Ensco.Irma.Models.Domain.Workflow;

namespace Ensco.Irma.Services.Workflow
{
    public class WorkflowService : EntityService<IrmaOapDbContext, Interfaces.Services.Data.IWorkflowRepository, workflow.Workflow, int>, IWorkflowService
    {
        public WorkflowService(Interfaces.Services.Data.IWorkflowRepository repository) : base(repository)
        {

        }

        public workflow.Workflow GetActiveWorkflow(int checklistLayoutId)
        {
            return Repository.GetActiveWorkflow(checklistLayoutId);
        }
    }
}
