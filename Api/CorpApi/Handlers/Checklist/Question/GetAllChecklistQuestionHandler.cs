using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Question;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Question
{
    public class GetAllChecklistQuestionHandler : IRequestHandler<GetAllChecklistQuestionRequest, IEnumerable<OapChecklistQuestion>>
    {
        private IOapChecklistQuestionService QuestionService { get; set; }

        public GetAllChecklistQuestionHandler(IOapChecklistQuestionService questionService)
        {
            QuestionService = questionService;
        }

        Task<IEnumerable<OapChecklistQuestion>> IRequestHandler<GetAllChecklistQuestionRequest, IEnumerable<OapChecklistQuestion>>.Handle(GetAllChecklistQuestionRequest request, CancellationToken cancellationToken)
        {
            var cl = QuestionService.GetAllChecklistQuestions(request.ChecklistId);
            return Task.FromResult(cl);
        }
    }
}