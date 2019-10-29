using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Finding
{
    using Ensco.Irma.Interfaces.Services.Oap;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding;

    public class GetFindingHandler : IRequestHandler<GetFindingRequest, RigOapChecklistFinding>
    {
        private IRigOapChecklistFindingService Service { get; set; }

        public GetFindingHandler(IRigOapChecklistFindingService findingService)
        {
            Service = findingService;
        }

        Task<RigOapChecklistFinding> IRequestHandler<GetFindingRequest, RigOapChecklistFinding>.Handle(GetFindingRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.Get(request.FindingId);
            return Task.FromResult(cl);
        }
    }
}