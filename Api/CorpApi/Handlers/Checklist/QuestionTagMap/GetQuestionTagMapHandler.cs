using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTagMap;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.QuestionTagMap
{
    public class GetQuestionTagMapHandler : IRequestHandler<GetQuestionTagMapRequest, OapChecklistQuestionTagMap>
    {
        private IOapChecklistQuestionTagMapService QuestionTagMapService { get; set; }

        public GetQuestionTagMapHandler(IOapChecklistQuestionTagMapService questionTagMapService)
        {
            QuestionTagMapService = questionTagMapService;
        }    

        Task<OapChecklistQuestionTagMap> IRequestHandler<GetQuestionTagMapRequest, OapChecklistQuestionTagMap>.Handle(GetQuestionTagMapRequest request, CancellationToken cancellationToken)
        {
            var tagMap = QuestionTagMapService.Get(request.QuestionTagMapId);
            return Task.FromResult(tagMap);
        }
    }
}