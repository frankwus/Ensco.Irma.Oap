using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionRelatedQuestionMap;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.QuestionRelatedQuestionMap
{
    public class DeleteQuestionRelatedQuestionMapHandler : IRequestHandler<DeleteQuestionRelatedQuestionMapRequest, bool>
    {
        private IOapChecklistQuestionRelatedQuestionMapService QuestionRelatedQuestionMapService { get; set; }

        public DeleteQuestionRelatedQuestionMapHandler(IOapChecklistQuestionRelatedQuestionMapService questionRelatedQuestionMapService)
        {
            QuestionRelatedQuestionMapService = questionRelatedQuestionMapService;
        }

        Task<bool> IRequestHandler<DeleteQuestionRelatedQuestionMapRequest, bool>.Handle(DeleteQuestionRelatedQuestionMapRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var QuestionTagMapId = QuestionRelatedQuestionMapService.Get(request.QuestionRelatedQuestionMapId);

                QuestionRelatedQuestionMapService.Delete(QuestionTagMapId);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}