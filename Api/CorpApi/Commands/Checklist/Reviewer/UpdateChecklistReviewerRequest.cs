using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Reviewer
{
    public class UpdateChecklistReviewerRequest : IRequest<bool>
    {
        public UpdateChecklistReviewerRequest(OapChecklistReviewer comment)
        {
            ChecklistReviewer = comment;
        }

        public OapChecklistReviewer ChecklistReviewer { get;  }
    }
}