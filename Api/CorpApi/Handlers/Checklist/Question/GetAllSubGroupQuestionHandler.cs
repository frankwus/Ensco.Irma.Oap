using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Question;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Question
{
    public class GetAllSubGroupQuestionHandler : IRequestHandler<GetAllSubGroupQuestionRequest, IEnumerable<OapChecklistQuestion>>
    {
        private IOapChecklistQuestionService QuestionService { get; set; }

        public GetAllSubGroupQuestionHandler(IOapChecklistQuestionService questionService)
        {
            QuestionService = questionService;
        }

        Task<IEnumerable<OapChecklistQuestion>> IRequestHandler<GetAllSubGroupQuestionRequest, IEnumerable<OapChecklistQuestion>>.Handle(GetAllSubGroupQuestionRequest request, CancellationToken cancellationToken)
        {
            var cl = QuestionService.GetAllSubGroupQuestions(request.SubGroupId);
            return Task.FromResult(cl);
        }
    }
}