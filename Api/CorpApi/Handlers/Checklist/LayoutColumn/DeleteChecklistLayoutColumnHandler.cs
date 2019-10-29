using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.LayoutColumn;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.LayoutColumn
{
    public class DeleteChecklistLayoutColumnHandler : IRequestHandler<DeleteChecklistLayoutColumnRequest, bool>
    {
        private IOapChecklistLayoutColumnService ChecklistLayoutColumnService { get; set; }

        public DeleteChecklistLayoutColumnHandler(IOapChecklistLayoutColumnService checklistLayoutColumnService)
        {
            ChecklistLayoutColumnService = checklistLayoutColumnService;
        }

        Task<bool> IRequestHandler<DeleteChecklistLayoutColumnRequest, bool>.Handle(DeleteChecklistLayoutColumnRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var ChecklistLayoutColumn = ChecklistLayoutColumnService.Get(request.ChecklistLayoutColumnId);
                 
                ChecklistLayoutColumnService.Delete(ChecklistLayoutColumn);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}