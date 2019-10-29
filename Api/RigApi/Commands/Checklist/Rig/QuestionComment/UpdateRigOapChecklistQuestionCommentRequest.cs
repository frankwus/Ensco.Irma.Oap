using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.Comment
{
    public class UpdateRigOapChecklistQuestionCommentRequest : IRequest<RigOapChecklistQuestionComment>
    {
        public UpdateRigOapChecklistQuestionCommentRequest(RigOapChecklistQuestionComment checklistQuestionComment)
        {
            RigChecklistQuestionComment = checklistQuestionComment;
        }

        public RigOapChecklistQuestionComment RigChecklistQuestionComment { get;  }
    }
}