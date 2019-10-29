using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Comment
{
    public class DeleteChecklistCommentRequest : IRequest<bool>
    { 
        public DeleteChecklistCommentRequest(int commentId)
        {
            ChecklistCommentId = commentId;
        }

        public int ChecklistCommentId { get; set;}
    }
}