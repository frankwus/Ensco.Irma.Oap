using Ensco.Irma.Data.Context;
using Ensco.Irma.Models.Domain.Workflow;
using Ensco.Irma.Interfaces.Services.Logging;
using System.Data.Entity;
using System.Linq;
using System;
using Ensco.Irma.Interfaces.Data.Repositories;

namespace Ensco.Irma.Data.Repositories
{
    public class WorkflowInstanceActivityRepository : BaseRepository<IrmaOapDbContext, WorkflowInstanceActivity, Guid>, IWorkflowInstanceActivityRepository
    {
        public WorkflowInstanceActivityRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext) context, log)
        {

        }
    }
}
