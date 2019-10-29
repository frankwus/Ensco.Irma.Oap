using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistWorkInstruction;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ChecklistWorkInstruction
{
    public class DeleteChecklistWorkInstructionHandler : IRequestHandler<DeleteChecklistWorkInstructionRequest, bool>
    {
        private IOapChecklistWorkInstructionService WorkInstructionService { get; set; }

        public DeleteChecklistWorkInstructionHandler(IOapChecklistWorkInstructionService workInstructionService)
        {
            WorkInstructionService = workInstructionService;
        }


        Task<bool> IRequestHandler<DeleteChecklistWorkInstructionRequest, bool>.Handle(DeleteChecklistWorkInstructionRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var ChecklistId = WorkInstructionService.Get(request.ChecklistWorkInstructionId);
               
                WorkInstructionService.Delete(ChecklistId);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}