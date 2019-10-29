using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Reviewer
{
    public class AddChecklistReviewerRequest : IRequest<OapChecklistReviewer>
    {
        public AddChecklistReviewerRequest(OapChecklistReviewer comment)
        {
            ChecklistReviewer = comment;
        }

        public OapChecklistReviewer ChecklistReviewer { get;  }
    }
}