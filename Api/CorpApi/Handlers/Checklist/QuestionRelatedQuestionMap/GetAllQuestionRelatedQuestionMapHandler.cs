using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionRelatedQuestionMap;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.QuestionRelatedQuestionMap
{
    public class GetAllQuestionRelatedQuestionMapHandler : IRequestHandler<GetAllQuestionRelatedQuestionMapRequest, IEnumerable<OapChecklistQuestion>>
    {

        private IOapChecklistQuestionRelatedQuestionMapService QuestionRelatedQuestionMapService { get; set; }

        public GetAllQuestionRelatedQuestionMapHandler(IOapChecklistQuestionRelatedQuestionMapService questionRelatedQuestionMapService)
        {
            QuestionRelatedQuestionMapService = questionRelatedQuestionMapService;
        }

        Task<IEnumerable<OapChecklistQuestion>> IRequestHandler<GetAllQuestionRelatedQuestionMapRequest, IEnumerable<OapChecklistQuestion>>.Handle(GetAllQuestionRelatedQuestionMapRequest request, CancellationToken cancellationToken)
        {
            var questionMaps = QuestionRelatedQuestionMapService.GetRelatedQuestions(request.QuestionId);
            return Task.FromResult(questionMaps);
        }
    }
}