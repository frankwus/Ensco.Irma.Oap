using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.OapAudits.AuditProtocol
{
    public class GetRelatedQuestionSearchProtocolHandler : IRequestHandler<GetRelatedQuestionSearchProtocolRequest, IEnumerable<RigOapChecklistQuestion>>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }
        public IOapChecklistQuestionRelatedQuestionMapService OapChecklistQuestionRelatedQuestionMapService { get; }

        public GetRelatedQuestionSearchProtocolHandler(IRigOapChecklistService rigOapChecklistService, IOapChecklistQuestionRelatedQuestionMapService oapChecklistQuestionRelatedQuestionMapService)
        {
            RigOapChecklistService = rigOapChecklistService;
            OapChecklistQuestionRelatedQuestionMapService = oapChecklistQuestionRelatedQuestionMapService;
        }

        public Task<IEnumerable<RigOapChecklistQuestion>> Handle(GetRelatedQuestionSearchProtocolRequest request, CancellationToken cancellationToken)
        {           
            var cl = RigOapChecklistService.GetRelatedQuestionSearch(request.QuestionId, request.FromDate,request.ToDate, request.SearchBy);
            return Task.FromResult(cl);
        }
 
    }
}