using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Reviewer;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Reviewer
{
    public class DeleteChecklistReviewerHandler : IRequestHandler<DeleteChecklistReviewerRequest, bool>
    {
        private IOapChecklistReviewerService ChecklistReviewerService { get; set; }

        public DeleteChecklistReviewerHandler(IOapChecklistReviewerService checklistReviewerService)
        {
            ChecklistReviewerService = checklistReviewerService;
        }

        Task<bool> IRequestHandler<DeleteChecklistReviewerRequest, bool>.Handle(DeleteChecklistReviewerRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var ChecklistReviewer = ChecklistReviewerService.Get(request.ChecklistReviewerId);
                 
                ChecklistReviewerService.Delete(ChecklistReviewer);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}