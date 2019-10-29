using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Reviewer
{
    public class GetChecklistReviewerRequest : IRequest<OapChecklistReviewer>
    { 
        public GetChecklistReviewerRequest(int commentId)
        {
            ChecklistReviewerId = commentId;
        }

        public int ChecklistReviewerId {get; set;}
    }
}