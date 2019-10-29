using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTagMap;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.QuestionTagMap
{
    public class GetAllTagMapsForQuestionHandler : IRequestHandler<GetAllTagMapsForQuestionRequest, IEnumerable<OapChecklistQuestionTagMap>>
    {

        private IOapChecklistQuestionTagMapService QuestionTagMapService { get; set; }

        public GetAllTagMapsForQuestionHandler(IOapChecklistQuestionTagMapService questionTagMapService)
        {
            QuestionTagMapService = questionTagMapService;
        }

        Task<IEnumerable<OapChecklistQuestionTagMap>> IRequestHandler<GetAllTagMapsForQuestionRequest, IEnumerable<OapChecklistQuestionTagMap>>.Handle(GetAllTagMapsForQuestionRequest request, CancellationToken cancellationToken)
        {
            var tagMaps = QuestionTagMapService.GetAllTagsByQuestion(request.QuestionId);
            return Task.FromResult(tagMaps);
        }
    }
}