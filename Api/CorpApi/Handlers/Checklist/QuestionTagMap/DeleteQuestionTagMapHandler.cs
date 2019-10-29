using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTagMap;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.QuestionTagMap
{
    public class DeleteQuestionTagMapHandler : IRequestHandler<DeleteQuestionTagMapRequest, bool>
    {
        private IOapChecklistQuestionTagMapService QuestionTagMapService { get; set; }

        public DeleteQuestionTagMapHandler(IOapChecklistQuestionTagMapService questionTagMapService)
        {
            QuestionTagMapService = questionTagMapService;
        }

        Task<bool> IRequestHandler<DeleteQuestionTagMapRequest, bool>.Handle(DeleteQuestionTagMapRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var QuestionTagMapId = QuestionTagMapService.Get(request.QuestionTagMapId);

                QuestionTagMapService.Delete(QuestionTagMapId);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}