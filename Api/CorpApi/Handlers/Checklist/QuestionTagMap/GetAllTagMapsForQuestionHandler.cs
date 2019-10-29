using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTagMap;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.QuestionTagMap
{
    public class GetAllQuestionTagMapHandler : IRequestHandler<GetAllQuestionTagMapRequest, IEnumerable<OapChecklistQuestionTagMap>>
    {

        private IOapChecklistQuestionTagMapService QuestionTagMapService { get; set; }

        public GetAllQuestionTagMapHandler(IOapChecklistQuestionTagMapService questionTagMapService)
        {
            QuestionTagMapService = questionTagMapService;
        }

        Task<IEnumerable<OapChecklistQuestionTagMap>> IRequestHandler<GetAllQuestionTagMapRequest, IEnumerable<OapChecklistQuestionTagMap>>.Handle(GetAllQuestionTagMapRequest request, CancellationToken cancellationToken)
        {
            var tagMaps = QuestionTagMapService.GetAll();
            return Task.FromResult(tagMaps);
        }
    }
}