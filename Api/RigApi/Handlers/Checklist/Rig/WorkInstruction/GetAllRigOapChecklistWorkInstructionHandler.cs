using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.WorkInstruction;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class GetAllRigOapChecklistWorkInstructionHandler : IRequestHandler<GetAllRigOapChecklistWorkInstructionRequest, IEnumerable<RigOapChecklistWorkInstruction>>
    {
        private IRigOapChecklistWorkInstructionService RigOapChecklistWorkInstructionService { get; set; }

        public GetAllRigOapChecklistWorkInstructionHandler(IRigOapChecklistWorkInstructionService rigOapChecklistWorkInstructionService)
        {
            RigOapChecklistWorkInstructionService = rigOapChecklistWorkInstructionService;
        }

        Task<IEnumerable<RigOapChecklistWorkInstruction>> IRequestHandler<GetAllRigOapChecklistWorkInstructionRequest, IEnumerable<RigOapChecklistWorkInstruction>>.Handle(GetAllRigOapChecklistWorkInstructionRequest request, CancellationToken cancellationToken)
        {
            var cl =  RigOapChecklistWorkInstructionService.GetAll();
            return Task.FromResult(cl);
        }
    }
}