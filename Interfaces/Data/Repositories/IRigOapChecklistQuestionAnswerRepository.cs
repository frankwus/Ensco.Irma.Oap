using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IRigOapChecklistQuestionAnswerRepository: IBaseIdRepository<RigOapChecklistQuestionAnswer, Guid>
    {
        IQueryable<RigOapChecklistQuestionAnswer> Filter(Expression<Func<RigOapChecklistQuestionAnswer, bool>> expression);
    }
}
