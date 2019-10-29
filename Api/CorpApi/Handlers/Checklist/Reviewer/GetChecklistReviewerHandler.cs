using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Reviewer;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Reviewer
{
    using Ensco.Irma.Extensions;

    public class GetChecklistReviewerHandler : IRequestHandler<GetChecklistReviewerRequest, OapChecklistReviewer>
    {
        private IOapChecklistReviewerService Service { get; set; }

        public GetChecklistReviewerHandler(IOapChecklistReviewerService ChecklistReviewerService)
        {
            Service = ChecklistReviewerService;
        }

        Task<OapChecklistReviewer> IRequestHandler<GetChecklistReviewerRequest, OapChecklistReviewer>.Handle(GetChecklistReviewerRequest request, CancellationToken cancellationToken)
        {
            var c = Service.Get(request.ChecklistReviewerId);             

            return Task.FromResult(c);
        }
    }
}