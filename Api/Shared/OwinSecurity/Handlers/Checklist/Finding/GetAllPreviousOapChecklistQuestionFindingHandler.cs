
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.Finding
{
    using Ensco.Irma.Interfaces.Services.Oap;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding;

    public class GetAllPreviousOapChecklistQuestionFindingHandler : IRequestHandler<GetAllPreviousOapChecklistQuestionFindingRequest, IEnumerable<RigOapChecklistQuestionFinding>>
    {
        private IRigOapChecklistQuestionFindingService Service { get; set; }

        public GetAllPreviousOapChecklistQuestionFindingHandler(IRigOapChecklistQuestionFindingService findingService)
        {
            Service = findingService;
        }

        Task<IEnumerable<RigOapChecklistQuestionFinding>> IRequestHandler<GetAllPreviousOapChecklistQuestionFindingRequest, IEnumerable<RigOapChecklistQuestionFinding>>.Handle(GetAllPreviousOapChecklistQuestionFindingRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAllQuestionPreviousFindings(request.RigQuestionId);
            return Task.FromResult(cl);
        }
    }
}