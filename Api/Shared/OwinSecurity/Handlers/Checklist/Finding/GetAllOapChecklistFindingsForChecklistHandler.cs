
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.Finding
{
    using Ensco.Irma.Interfaces.Services.Oap;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding;

    public class GetAllOapChecklistFindingsForChecklistHandler : IRequestHandler<GetAllOapChecklistFindingsForChecklistRequest, IEnumerable<RigOapChecklistQuestionFinding>>
    {
        private IRigOapChecklistQuestionFindingService Service { get; set; }

        public GetAllOapChecklistFindingsForChecklistHandler(IRigOapChecklistQuestionFindingService findingService)
        {
            Service = findingService;
        }
 
        Task<IEnumerable<RigOapChecklistQuestionFinding>> IRequestHandler<GetAllOapChecklistFindingsForChecklistRequest, IEnumerable<RigOapChecklistQuestionFinding>>.Handle(GetAllOapChecklistFindingsForChecklistRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAllChecklistFindings(request.RigChecklistId);
            return Task.FromResult(cl);
        }
    }
}