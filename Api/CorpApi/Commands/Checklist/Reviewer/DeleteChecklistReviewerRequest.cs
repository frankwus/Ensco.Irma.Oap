using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Reviewer
{
    public class DeleteChecklistReviewerRequest : IRequest<bool>
    { 
        public DeleteChecklistReviewerRequest(int commentId)
        {
            ChecklistReviewerId = commentId;
        }

        public int ChecklistReviewerId { get; set;}
    }
}