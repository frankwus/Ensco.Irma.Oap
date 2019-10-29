using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.WorkInstruction
{
    public class GetRigOapChecklistWorkInstructionRequest : IRequest<RigOapChecklistWorkInstruction>
    { 
        public GetRigOapChecklistWorkInstructionRequest(Guid rigOapChecklistWorkInstructionId)
        {
            RigOapChecklistWorkInstructionId = rigOapChecklistWorkInstructionId;
        }

        public Guid RigOapChecklistWorkInstructionId { get; set; }
    }
}