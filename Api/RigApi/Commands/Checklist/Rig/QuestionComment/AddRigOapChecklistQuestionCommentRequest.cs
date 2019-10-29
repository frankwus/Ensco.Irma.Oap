using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.Comment
{
    public class AddRigOapChecklistQuestionCommentRequest : IRequest<RigOapChecklistQuestionComment>
    {
        public AddRigOapChecklistQuestionCommentRequest(RigOapChecklistQuestionComment comment)
        {
            Comment = comment;
        }

        public RigOapChecklistQuestionComment Comment { get;  }
    }
}