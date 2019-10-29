using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.WorkInstruction;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.WorkInstruction
{

    public class UpdateWorkInstructionHandler : IRequestHandler<UpdateWorkInstructionRequest, bool>
    {
        private IOapWorkInstructionService WorkInstructionService { get; set; }
        private IMapper Mapper { get; set; }
        public UpdateWorkInstructionHandler(IOapWorkInstructionService workInstructionService, IMapper mapper)
        {
            WorkInstructionService = workInstructionService;
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateWorkInstructionRequest, bool>.Handle(UpdateWorkInstructionRequest request, CancellationToken cancellationToken)
        {
            var existingWorkInstruction = WorkInstructionService.Get(request.WorkInstruction.Id);

            if (existingWorkInstruction == null)
            {
                throw new ApplicationException($"UpdateWorkInstructionHandler: WorkInstruction with Id {request.WorkInstruction.Id} does not exist.");
            }

            var checkDuplicate = WorkInstructionService.Get(request.WorkInstruction.Id);
            if (checkDuplicate != null)
            {
                throw new ApplicationException($"UpdateWorkInstructionHandler: WorkInstruction with Id  {request.WorkInstruction.Id} already exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.WorkInstruction.Id, existingWorkInstruction);

            using (var ts = new TransactionScope())
            {
                var updatedQuestionTagMap = WorkInstructionService.Update(existingWorkInstruction);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}