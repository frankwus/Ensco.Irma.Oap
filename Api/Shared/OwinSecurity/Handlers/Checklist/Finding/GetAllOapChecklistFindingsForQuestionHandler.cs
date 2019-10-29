
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.Finding
{
    using Ensco.Irma.Interfaces.Services.Oap;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding;

    public class GetAllOapChecklistFindingsForQuestionHandler : IRequestHandler<GetAllOapChecklistFindingsForQuestionRequest, IEnumerable<RigOapChecklistQuestionFinding>>
    {
        private IRigOapChecklistQuestionFindingService Service { get; set; }

        public GetAllOapChecklistFindingsForQuestionHandler(IRigOapChecklistQuestionFindingService findingService)
        {
            Service = findingService;
        }
 
        Task<IEnumerable<RigOapChecklistQuestionFinding>> IRequestHandler<GetAllOapChecklistFindingsForQuestionRequest, IEnumerable<RigOapChecklistQuestionFinding>>.Handle(GetAllOapChecklistFindingsForQuestionRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAllQuestionFindings(request.RigQuestionId);
            return Task.FromResult(cl);
        }
    }
}