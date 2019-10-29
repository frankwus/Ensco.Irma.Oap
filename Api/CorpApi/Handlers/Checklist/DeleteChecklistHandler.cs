using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist
{
    public class DeleteChecklistHandler : IRequestHandler<DeleteChecklistRequest, bool>
    {
        private IOapChecklistService ChecklistService { get; set; }

        public DeleteChecklistHandler(IOapChecklistService checklistService)
        {
            ChecklistService = checklistService; 
        }

        Task<bool> IRequestHandler<DeleteChecklistRequest, bool>.Handle(DeleteChecklistRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var checklist = ChecklistService.Get(request.ChecklistId);

                checklist.EndDateTime = DateTime.UtcNow;

                ChecklistService.Update(checklist);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}