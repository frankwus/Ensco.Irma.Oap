using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Models.Domain.Workflow;

namespace Ensco.Irma.Interfaces.Services.Data
{
    public interface IWorkflowRepository: IBaseRepository<Workflow,int>
    {
        Workflow GetActiveWorkflow(int checklistLayoutId);
         
    }
}
