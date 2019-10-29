using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Question;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Question
{
    public class GetAllTopicQuestionHandler : IRequestHandler<GetAllTopicQuestionRequest, IEnumerable<OapChecklistQuestion>>
    {
        private IOapChecklistQuestionService QuestionService { get; set; }

        public GetAllTopicQuestionHandler(IOapChecklistQuestionService questionService)
        {
            QuestionService = questionService;
        }

        Task<IEnumerable<OapChecklistQuestion>> IRequestHandler<GetAllTopicQuestionRequest, IEnumerable<OapChecklistQuestion>>.Handle(GetAllTopicQuestionRequest request, CancellationToken cancellationToken)
        {
            var cl = QuestionService.GetAllTopicQuestions(request.TopicId);
            return Task.FromResult(cl);
        }
    }
}