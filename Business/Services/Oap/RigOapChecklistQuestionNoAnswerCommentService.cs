using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ensco.Irma.Services.Oap
{
    public class RigOapChecklistQuestionNoAnswerCommentService : EntityIdService<IrmaOapDbContext, IRigOapChecklistQuestionNoAnswerCommentRepository, RigOapChecklistQuestionNoAnswerComment, Guid>, IRigOapChecklistQuestionNoAnswerCommentService
    {

        public RigOapChecklistQuestionNoAnswerCommentService(IRigOapChecklistQuestionNoAnswerCommentRepository rigOapChecklistQuestionNoAnswerCommentRepository) : base(rigOapChecklistQuestionNoAnswerCommentRepository)
        {
        }        

        public IEnumerable<RigOapChecklistQuestionNoAnswerComment> GetByOapQuestionId(int oapChecklistQuestionId)
        {
            return Repository.GetByOapQuestionId(oapChecklistQuestionId);
        }

        public IEnumerable<RigOapChecklistQuestionNoAnswerComment> GetOpenNoAnswers(int oapChecklistId, int oapChecklistQuestionId)
        {
            return Repository.GetOpenNoAnswers(oapChecklistId, oapChecklistQuestionId);
        }
    }
}
