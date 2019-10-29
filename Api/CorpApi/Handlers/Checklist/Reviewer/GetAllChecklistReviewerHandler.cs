using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Reviewer;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Reviewer
{
    using Ensco.Irma.Extensions;

    public class GetAllChecklistReviewerHandler : IRequestHandler<GetAllChecklistReviewerRequest, IEnumerable<OapChecklistReviewer>>
    {
        private IOapChecklistReviewerService Service { get; set; }

        public GetAllChecklistReviewerHandler(IOapChecklistReviewerService ChecklistReviewerService)
        {
            Service = ChecklistReviewerService;
        }

        Task<IEnumerable<OapChecklistReviewer>> IRequestHandler<GetAllChecklistReviewerRequest, IEnumerable<OapChecklistReviewer>>.Handle(GetAllChecklistReviewerRequest request, CancellationToken cancellationToken)
        {
            var list = Service.GetAll(request.StartDate, request.EndDate);            

            return Task.FromResult(list);
        }
    }
}