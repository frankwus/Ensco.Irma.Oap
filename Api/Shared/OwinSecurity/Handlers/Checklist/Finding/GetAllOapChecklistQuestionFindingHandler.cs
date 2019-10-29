
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.Finding
{
    using Ensco.Irma.Interfaces.Services.Oap;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding;

    public class GetAllOapChecklistQuestionFindingHandler : IRequestHandler<GetAllOapChecklistQuestionFindingRequest, IEnumerable<RigOapChecklistQuestionFinding>>
    {
        private IRigOapChecklistQuestionFindingService Service { get; set; }

        public GetAllOapChecklistQuestionFindingHandler(IRigOapChecklistQuestionFindingService findingService)
        {
            Service = findingService;
        }

        Task<IEnumerable<RigOapChecklistQuestionFinding>> IRequestHandler<GetAllOapChecklistQuestionFindingRequest, IEnumerable<RigOapChecklistQuestionFinding>>.Handle(GetAllOapChecklistQuestionFindingRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAll();
            return Task.FromResult(cl);
        }
    }
}