using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.NoAnswerComment
{
    public class AddRigOapChecklistQuestionNoAnswerCommentRequest : IRequest<RigOapChecklistQuestionNoAnswerComment>
    {
        public AddRigOapChecklistQuestionNoAnswerCommentRequest(RigOapChecklistQuestionNoAnswerComment comment)
        {
            Comment = comment;
        }

        public RigOapChecklistQuestionNoAnswerComment Comment { get;  }
    }
}