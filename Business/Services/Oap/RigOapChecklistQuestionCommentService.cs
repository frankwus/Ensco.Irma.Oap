using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;

namespace Ensco.Irma.Services.Oap
{
    public class RigOapChecklistQuestionCommentService : EntityIdService<IrmaOapDbContext, IRigOapChecklistQuestionCommentRepository, RigOapChecklistQuestionComment, Guid>, IRigOapChecklistQuestionCommentService
    {

        public RigOapChecklistQuestionCommentService(IRigOapChecklistQuestionCommentRepository rigOapChecklistQuestionCommentRepository) : base(rigOapChecklistQuestionCommentRepository)
        {
        }
    }
}
