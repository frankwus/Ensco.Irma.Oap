using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Question;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Question
{
    public class GetChecklistQuestionHandler : IRequestHandler<GetChecklistQuestionRequest, OapChecklistQuestion>
    {
        private IOapChecklistQuestionService QuestionService { get; set; }

        public GetChecklistQuestionHandler(IOapChecklistQuestionService questionService)
        {
            QuestionService = questionService;
        }

        Task<OapChecklistQuestion> IRequestHandler<GetChecklistQuestionRequest, OapChecklistQuestion>.Handle(GetChecklistQuestionRequest request, CancellationToken cancellationToken)
        {
            var cl = QuestionService.Get(request.QuestionId);
            return Task.FromResult(cl);
        }
    }
}