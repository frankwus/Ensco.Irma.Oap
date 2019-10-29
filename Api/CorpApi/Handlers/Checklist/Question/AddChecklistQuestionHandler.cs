using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Question;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Question
{
    public class AddChecklistQuestionHandler : IRequestHandler<AddChecklistQuestionRequest, OapChecklistQuestion>
    {
        private IOapChecklistQuestionService QuestionService { get; set; }
    
        public AddChecklistQuestionHandler(IOapChecklistQuestionService questionService)
        {
            QuestionService = questionService; 
        }

        Task<OapChecklistQuestion> IRequestHandler<AddChecklistQuestionRequest, OapChecklistQuestion>.Handle(AddChecklistQuestionRequest request, CancellationToken cancellationToken)
        {

            int QuestionId = 0;
            using (var ts = new TransactionScope())
            {
                QuestionId = QuestionService.Add(request.Question); 
                
                ts.Complete();
            }

            return Task.FromResult(QuestionService.Get(QuestionId));
        }

         
    }
}