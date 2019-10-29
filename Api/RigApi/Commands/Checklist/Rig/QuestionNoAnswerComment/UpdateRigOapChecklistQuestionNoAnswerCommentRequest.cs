using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.NoAnswerComment
{
    public class UpdateRigOapChecklistQuestionNoAnswerCommentRequest : IRequest<RigOapChecklistQuestionNoAnswerComment>
    {
        public UpdateRigOapChecklistQuestionNoAnswerCommentRequest(RigOapChecklistQuestionNoAnswerComment checklistQuestionNoAnswerComment)
        {
            RigChecklistQuestionNoAnswerComment = checklistQuestionNoAnswerComment;
        }

        public RigOapChecklistQuestionNoAnswerComment RigChecklistQuestionNoAnswerComment { get;  }
    }
}