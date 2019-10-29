using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.Comment
{
    public class DeleteRigOapChecklistQuestionCommentRequest : IRequest<bool>
    { 
        public DeleteRigOapChecklistQuestionCommentRequest(Guid commentId)
        {
            CommentId = commentId;
        }

        public Guid  CommentId {get; set;}
    }
}