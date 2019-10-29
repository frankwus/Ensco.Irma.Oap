using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistWorkInstruction;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ChecklistWorkInstruction
{
    public class UpdateChecklistWorkInstructionHandler : IRequestHandler<UpdateChecklistWorkInstructionRequest, bool>
    {
        private IOapChecklistWorkInstructionService WorkInstructionService { get; set; }
        private IMapper Mapper { get; set; }
        public UpdateChecklistWorkInstructionHandler(IOapChecklistWorkInstructionService workInstructionService, IMapper mapper)
        {
            WorkInstructionService = workInstructionService;
            Mapper = mapper;
        }        

        Task<bool> IRequestHandler<UpdateChecklistWorkInstructionRequest, bool>.Handle(UpdateChecklistWorkInstructionRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistWorkInstruction = WorkInstructionService.Get(request.ChecklistWorkInstruction.Id);

            if (existingChecklistWorkInstruction == null)
            {
                throw new ApplicationException($"UpdateChecklistWorkInstructionHandler: ChecklistWorkInstruction with Id {request.ChecklistWorkInstruction.Id} does not exist.");
            }           

            //AutoMapper to Map the fields 
            Mapper.Map(request.ChecklistWorkInstruction, existingChecklistWorkInstruction);

            using (var ts = new TransactionScope())
            {
                var updatedChecklistEquipment = WorkInstructionService.Update(existingChecklistWorkInstruction);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}