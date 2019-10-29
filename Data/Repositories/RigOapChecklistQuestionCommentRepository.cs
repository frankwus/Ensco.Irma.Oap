
using System;

namespace Ensco.Irma.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using Ensco.Irma.Data.Context;
    using Ensco.Irma.Interfaces.Data.Repositories;
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;

    public class RigOapChecklistQuestionCommentRepository : BaseIdRepository<IrmaOapDbContext, RigOapChecklistQuestionComment, Guid>, IRigOapChecklistQuestionCommentRepository
    {
        public RigOapChecklistQuestionCommentRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext) context, log)
        {

        }
    }

}
