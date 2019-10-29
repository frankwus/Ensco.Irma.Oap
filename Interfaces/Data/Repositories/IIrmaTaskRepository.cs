using Ensco.Irma.Models.Domain.IRMA;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ensco.Irma.Interfaces.Data.Repositories.Irma
{
    public interface IIrmaTaskRepository : IBaseIdRepository<IrmaTask, int>
    {

        IrmaTask GetBySourceAssignee(string sourceForm, int sourceId, int assigneeId);
        IQueryable<IrmaTask> Filter(Expression<Func<IrmaTask, bool>> expression);
    }
}
