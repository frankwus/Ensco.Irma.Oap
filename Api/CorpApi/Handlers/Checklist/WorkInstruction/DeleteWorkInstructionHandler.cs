using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.WorkInstruction;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.WorkInstruction
{
    public class DeleteWorkInstructionHandler : IRequestHandler<DeleteWorkInstructionRequest, bool>
    {
        private IOapWorkInstructionService WorkInstructionService { get; set; }

        public DeleteWorkInstructionHandler(IOapWorkInstructionService workInstructionService)
        {
            WorkInstructionService = workInstructionService;
        }



        Task<bool> IRequestHandler<DeleteWorkInstructionRequest, bool>.Handle(DeleteWorkInstructionRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var WorkInstructionId = WorkInstructionService.Get(request.WorkInstructionId);

                WorkInstructionService.Delete(WorkInstructionId);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}