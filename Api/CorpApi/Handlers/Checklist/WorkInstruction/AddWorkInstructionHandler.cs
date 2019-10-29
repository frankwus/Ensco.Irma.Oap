using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.WorkInstruction;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.WorkInstruction
{
    public class AddWorkInstructionHandler : IRequestHandler<AddWorkInstructionRequest, OapWorkInstruction>
    {
        private IOapWorkInstructionService WorkInstructionService { get; set; }

        public AddWorkInstructionHandler(IOapWorkInstructionService workInstructionService)
        {
            WorkInstructionService = workInstructionService;
        }

        Task<OapWorkInstruction> IRequestHandler<AddWorkInstructionRequest, OapWorkInstruction>.Handle(AddWorkInstructionRequest request, CancellationToken cancellationToken)
        {
            var existingWorkInstruction = WorkInstructionService.Get(request.WorkInstruction.Id); 
            if (existingWorkInstruction != null)
            {     
                return Task.FromResult((OapWorkInstruction) null);
            }

            int newWorkInstructionId = 0;
            using (var ts = new TransactionScope())
            {
                newWorkInstructionId = WorkInstructionService.Add(request.WorkInstruction);

                ts.Complete();
            }
            return Task.FromResult(WorkInstructionService.Get(newWorkInstructionId));
        }
              
    }
}