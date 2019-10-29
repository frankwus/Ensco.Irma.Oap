using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories.Irma;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Interfaces.Services;
using Ensco.Irma.Models.Domain.IRMA;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace Ensco.Irma.Services.Irma
{
    public class IrmaTaskService : EntityIdService<IrmaDbContext, IIrmaTaskRepository, IrmaTask, int>, IIrmaTaskService
    {
        public IrmaTaskService(IIrmaTaskRepository repository, ILog log) : base(repository, log)
        {
        }

        public bool CloseTask(string sourceForm, int sourceId, int assigneeId)
        {
            try
            {
                var existingTask = GetBySourceAssignee(sourceForm, sourceId, assigneeId);
                if (existingTask != null)
                {
                    existingTask.Status = "Closed";
                    Update(existingTask);
                }
                return true;
            }
            catch
            {
                return false;
            }            
        }

        public IrmaTask GetBySourceAssignee(string sourceForm, int sourceId, int assigneeId)
        {
            return Repository.GetBySourceAssignee(sourceForm, sourceId, assigneeId);
        }

        public IQueryable<IrmaTask> Filter(Expression<Func<IrmaTask,bool>> expression)
        {
            return Repository.Filter(expression);
        }
    }
}
