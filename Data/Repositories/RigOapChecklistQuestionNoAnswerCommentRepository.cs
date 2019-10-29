
using System;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    using Ensco.Irma.Data.Context;
    using Ensco.Irma.Interfaces.Data.Repositories;
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;

    public class RigOapChecklistQuestionNoAnswerCommentRepository : BaseIdRepository<IrmaOapDbContext, RigOapChecklistQuestionNoAnswerComment, Guid>, IRigOapChecklistQuestionNoAnswerCommentRepository
    {
        public RigOapChecklistQuestionNoAnswerCommentRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext) context, log)
        {

        }

        public IEnumerable<RigOapChecklistQuestionNoAnswerComment> GetByOapQuestionId(int oapChecklistQuestionId)
        {
            var items = AllItems.Where(n => n.OapChecklistQuestionId == oapChecklistQuestionId).OrderBy(n => n.StartDateTime).ToList();
            return items;
        }        

        public IEnumerable<RigOapChecklistQuestionNoAnswerComment> GetOpenNoAnswers(int oapChecklistId, int oapChecklistQuestionId)
        {
            var items = AllItems.Where(
                n => n.OapChecklistId == oapChecklistId && n.OapChecklistQuestionId == oapChecklistQuestionId && n.EndDateTime == null)
                .ToList();

            return items;
        }

        public override RigOapChecklistQuestionNoAnswerComment Get(Guid id)
        {
            return Context.RigOapCheckListQuestionNoAnswerComments.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }

        public override RigOapChecklistQuestionNoAnswerComment Update(RigOapChecklistQuestionNoAnswerComment entity)
        {
            var dbEntity = Context.RigOapCheckListQuestionNoAnswerComments.FirstOrDefault(a => a.Id == entity.Id);           

            if (dbEntity != null)
            {
                dbEntity.Comment = entity.Comment;
                dbEntity.IsStopWorkAuthorityExercised = entity.IsStopWorkAuthorityExercised ?? dbEntity.IsStopWorkAuthorityExercised;
                dbEntity.WasAbletoCorrectImmediately = entity.WasAbletoCorrectImmediately ?? dbEntity.WasAbletoCorrectImmediately;
                dbEntity.Correction = entity.Correction;
                dbEntity.EndCommentBy = entity.EndCommentBy;
                dbEntity.EndDateTime = entity.EndDateTime;
                dbEntity.ClosureRigOapChecklistId = entity.ClosureRigOapChecklistId;
            }
            Context.SaveChanges();
            return dbEntity;            
        }
    }

}
