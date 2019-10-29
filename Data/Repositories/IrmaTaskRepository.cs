using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories.Irma;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.IRMA;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ensco.Irma.Data.Repositories
{
    public class IrmaTaskRepository : BaseIdRepository<IrmaDbContext, IrmaTask, int>, IIrmaTaskRepository
    {
        public IrmaTaskRepository(IIrmaDbContext context, ILog log) : base((IrmaDbContext) context, log)
        {

        }

        public IQueryable<IrmaTask> Filter(Expression<Func<IrmaTask, bool>> expression)
        {
            return AllItems.Where(expression);
        }

        public IrmaTask GetBySourceAssignee(string sourceForm, int sourceId, int assigneeId)
        {
            return (from t in AllItems
                    where t.Source == sourceForm && t.SourceId == sourceId.ToString() && t.AssigneeId == assigneeId
                    select t).FirstOrDefault();
        }
    }
}
