using Ensco.Irma.Data.Context;
using Ensco.Irma.Models.Domain.Workflow;
using Ensco.Irma.Interfaces.Services.Data;
using Ensco.Irma.Interfaces.Services.Logging;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    public class WorkflowRepository : BaseRepository<IrmaOapDbContext, Workflow, int>, IWorkflowRepository
    {
        public WorkflowRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext) context, log)
        {

        }

        public Workflow GetActiveWorkflow(int checklistLayoutId)
        {
            return AllItems.First(wf => wf.Active == true && wf.ChecklistLayoutId == checklistLayoutId);
        }
    }
}
