using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Comment;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Comment
{
    public class DeleteChecklistCommentHandler : IRequestHandler<DeleteChecklistCommentRequest, bool>
    {
        private IOapChecklistCommentService ChecklistCommentService { get; set; }

        public DeleteChecklistCommentHandler(IOapChecklistCommentService checklistCommentService)
        {
            ChecklistCommentService = checklistCommentService;
        }

        Task<bool> IRequestHandler<DeleteChecklistCommentRequest, bool>.Handle(DeleteChecklistCommentRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var ChecklistComment = ChecklistCommentService.Get(request.ChecklistCommentId);
                 
                ChecklistCommentService.Delete(ChecklistComment);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}