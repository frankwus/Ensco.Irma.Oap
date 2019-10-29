using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.NoAnswerComment
{
    public class DeleteRigOapChecklistQuestionNoAnswerCommentRequest : IRequest<bool>
    { 
        public DeleteRigOapChecklistQuestionNoAnswerCommentRequest(Guid commentId)
        {
            CommentId = commentId;
        }

        public Guid  CommentId {get; set;}
    }
}