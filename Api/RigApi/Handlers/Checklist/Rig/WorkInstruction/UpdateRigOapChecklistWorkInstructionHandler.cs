using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Linq;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.WorkInstruction;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class UpdateRigOapChecklistWorkInstructionHandler : IRequestHandler<UpdateRigOapChecklistWorkInstructionRequest, RigOapChecklistWorkInstruction>
    {
        private IRigOapChecklistWorkInstructionService RigOapChecklistWorkInstructionService { get; set; }
        public IMapper AutoMapper { get; }

        public UpdateRigOapChecklistWorkInstructionHandler(IRigOapChecklistWorkInstructionService rigOapChecklistWorkInstructionService, IMapper mapper)
        {
            RigOapChecklistWorkInstructionService = rigOapChecklistWorkInstructionService;
            AutoMapper = mapper;
        }

        Task<RigOapChecklistWorkInstruction> IRequestHandler<UpdateRigOapChecklistWorkInstructionRequest, RigOapChecklistWorkInstruction>.Handle(UpdateRigOapChecklistWorkInstructionRequest request, CancellationToken cancellationToken)
        {
            var existingCheckList = RigOapChecklistWorkInstructionService.Get(request.RigChecklistWorkInstruction.Id);

            if (existingCheckList == null)
            {
                throw new ApplicationException($"{GetType().Name}: RigChecklist with Id {request.RigChecklistWorkInstruction.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            AutoMapper.Map(request.RigChecklistWorkInstruction, existingCheckList);

            using (var ts = new TransactionScope())
            {
                RigOapChecklistWorkInstructionService.Update(existingCheckList);

                ts.Complete();
            }
             
            return Task.FromResult(existingCheckList);
        } 
    }
}