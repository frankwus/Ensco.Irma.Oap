using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Question;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Question
{
    public class DeleteChecklistQuestionHandler : IRequestHandler<DeleteChecklistQuestionRequest, bool>
    {
        private IOapChecklistQuestionService QuestionService { get; set; }

        public DeleteChecklistQuestionHandler(IOapChecklistQuestionService questionService)
        {
            QuestionService = questionService;
        }

        Task<bool> IRequestHandler<DeleteChecklistQuestionRequest, bool>.Handle(DeleteChecklistQuestionRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var Question = QuestionService.Get(request.QuestionId);
                 
                QuestionService.Delete(Question);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}