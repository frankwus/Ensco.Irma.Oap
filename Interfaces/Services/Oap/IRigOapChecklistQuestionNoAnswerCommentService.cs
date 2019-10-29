using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IRigOapChecklistQuestionNoAnswerCommentService : IEntityIdService<RigOapChecklistQuestionNoAnswerComment, Guid>
    {
        IEnumerable<RigOapChecklistQuestionNoAnswerComment> GetByOapQuestionId(int oapChecklistQuestionId);
        IEnumerable<RigOapChecklistQuestionNoAnswerComment> GetOpenNoAnswers(int oapChecklistId, int oapChecklistQuestionId);
    }
}
