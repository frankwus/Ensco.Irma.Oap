using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistWorkInstruction;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ChecklistWorkInstruction
{
    public class AddChecklistWorkInstructionHandler : IRequestHandler<AddChecklistWorkInstructionRequest, OapChecklistWorkInstruction>
    {
        private IOapChecklistWorkInstructionService WorkInstructionService { get; set; }

        public AddChecklistWorkInstructionHandler(IOapChecklistWorkInstructionService workInstructionService)
        {
            WorkInstructionService = workInstructionService;
        }

        Task<OapChecklistWorkInstruction> IRequestHandler<AddChecklistWorkInstructionRequest, OapChecklistWorkInstruction>.Handle(AddChecklistWorkInstructionRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistWorkInstruction = WorkInstructionService.GetWorkInstructionByChecklistAndRigId(request.ChecklistWorkInstruction.RigId,request.ChecklistWorkInstruction.OapChecklistId, request.ChecklistWorkInstruction.OapWorkInstructionId);

            if (existingChecklistWorkInstruction != null)
            {
                return Task.FromResult((OapChecklistWorkInstruction)null);
            }

            int newChecklistWorkInstructionId = 0;
            using (var ts = new TransactionScope())
            {
                newChecklistWorkInstructionId = WorkInstructionService.Add(request.ChecklistWorkInstruction);

                ts.Complete();
            }
            return Task.FromResult(WorkInstructionService.Get(newChecklistWorkInstructionId));
        }
    }
}