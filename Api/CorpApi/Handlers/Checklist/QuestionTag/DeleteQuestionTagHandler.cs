using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTag;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.QuestionTag
{
    public class DeleteQuestionTagHandler : IRequestHandler<DeleteQuestionTagRequest, bool>
    {
        private IOapChecklistQuestionTagService QuestionTagService { get; set; }

        public DeleteQuestionTagHandler(IOapChecklistQuestionTagService questionTagService)
        {
            QuestionTagService = questionTagService;
        }

        Task<bool> IRequestHandler<DeleteQuestionTagRequest, bool>.Handle(DeleteQuestionTagRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var QuestionTag = QuestionTagService.Get(request.QuestionTagId);

                QuestionTagService.Delete(QuestionTag);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}