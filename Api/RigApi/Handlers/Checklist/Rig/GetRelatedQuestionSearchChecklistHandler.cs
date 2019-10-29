using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class GetRelatedQuestionSearchChecklistHandler : IRequestHandler<GetRelatedQuestionSearchChecklistRequest, IEnumerable<RigOapChecklistQuestion>>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }
        public IOapChecklistQuestionRelatedQuestionMapService OapChecklistQuestionRelatedQuestionMapService { get; }

        public GetRelatedQuestionSearchChecklistHandler(IRigOapChecklistService rigOapChecklistService, IOapChecklistQuestionRelatedQuestionMapService oapChecklistQuestionRelatedQuestionMapService)
        {
            RigOapChecklistService = rigOapChecklistService;
            OapChecklistQuestionRelatedQuestionMapService = oapChecklistQuestionRelatedQuestionMapService;
        }

        public Task<IEnumerable<RigOapChecklistQuestion>> Handle(GetRelatedQuestionSearchChecklistRequest request, CancellationToken cancellationToken)
        {
           
            var cl = RigOapChecklistService.GetRelatedQuestionSearch(request.QuestionId, request.FromDate,request.ToDate, request.SearchBy);
            return Task.FromResult(cl);
        }
 
    }
}