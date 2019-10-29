using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.Finding
{
    public class DeleteOapChecklistQuestionFindingHandler : IRequestHandler<DeleteOapChecklistQuestionFindingRequest, bool>
    {
        private IRigOapChecklistQuestionFindingService FindingService { get; set; }

        public DeleteOapChecklistQuestionFindingHandler(IRigOapChecklistQuestionFindingService frequencyTypeService)
        {
            FindingService = frequencyTypeService;
        }

        Task<bool> IRequestHandler<DeleteOapChecklistQuestionFindingRequest, bool>.Handle(DeleteOapChecklistQuestionFindingRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var Finding = FindingService.Get(request.FindingId);
                 
                FindingService.Delete(Finding);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}