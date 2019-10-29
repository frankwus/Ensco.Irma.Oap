
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    using Ensco.Irma.Data.Context;
    using Ensco.Irma.Interfaces.Data.Repositories;
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using System.Linq.Expressions;

    public class RigOapChecklistQuestionAnswerRepository : BaseIdRepository<IrmaOapDbContext, RigOapChecklistQuestionAnswer, Guid>, IRigOapChecklistQuestionAnswerRepository
    {
        public RigOapChecklistQuestionAnswerRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        public IQueryable<RigOapChecklistQuestionAnswer> Filter(Expression<Func<RigOapChecklistQuestionAnswer, bool>> expression)
        {
            return AllItems.Where(expression);
        }

    }
}
