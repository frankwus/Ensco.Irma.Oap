using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.WorkInstruction;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class DeleteRigOapChecklistWorkInstructionHandler : IRequestHandler<DeleteRigOapChecklistWorkInstructionRequest, bool>
    {
        private IRigOapChecklistWorkInstructionService RigOapChecklistWorkInstructionService { get; set; }

        public DeleteRigOapChecklistWorkInstructionHandler(IRigOapChecklistWorkInstructionService rigOapChecklistWorkInstructionService)
        {
            RigOapChecklistWorkInstructionService = rigOapChecklistWorkInstructionService;
        }

        Task<bool> IRequestHandler<DeleteRigOapChecklistWorkInstructionRequest, bool>.Handle(DeleteRigOapChecklistWorkInstructionRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var rigOapChecklistWorkInstruction = RigOapChecklistWorkInstructionService.Get(request.WorkInstructionId);

                RigOapChecklistWorkInstructionService.Delete(rigOapChecklistWorkInstruction);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}