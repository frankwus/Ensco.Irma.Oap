using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Finding
{
    using Ensco.Irma.Interfaces.Services.Oap;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding;

    public class GetOapChecklistQuestionFindingHandler : IRequestHandler<GetOapChecklistQuestionFindingRequest, RigOapChecklistQuestionFinding>
    {
        private IRigOapChecklistQuestionFindingService Service { get; set; }

        public GetOapChecklistQuestionFindingHandler(IRigOapChecklistQuestionFindingService findingService)
        {
            Service = findingService;
        }

        Task<RigOapChecklistQuestionFinding> IRequestHandler<GetOapChecklistQuestionFindingRequest, RigOapChecklistQuestionFinding>.Handle(GetOapChecklistQuestionFindingRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.Get(request.FindingId);
            return Task.FromResult(cl);
        }
    }
}