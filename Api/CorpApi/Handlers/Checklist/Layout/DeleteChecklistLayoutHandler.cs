using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Layout;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Layout
{
    public class DeleteChecklistLayoutHandler : IRequestHandler<DeleteChecklistLayoutRequest, bool>
    {
        private IOapChecklistLayoutService ChecklistLayoutService { get; set; }

        public DeleteChecklistLayoutHandler(IOapChecklistLayoutService checklistLayoutService)
        {
            ChecklistLayoutService = checklistLayoutService;
        }

        Task<bool> IRequestHandler<DeleteChecklistLayoutRequest, bool>.Handle(DeleteChecklistLayoutRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var ChecklistLayout = ChecklistLayoutService.Get(request.ChecklistLayoutId);
                 
                ChecklistLayoutService.Delete(ChecklistLayout);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}