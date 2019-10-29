using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.WorkInstruction
{
    public class DeleteRigOapChecklistWorkInstructionRequest : IRequest<bool>
    { 
        public DeleteRigOapChecklistWorkInstructionRequest(Guid workInstructionId)
        {
            WorkInstructionId = workInstructionId;
        }

        public Guid WorkInstructionId { get; set;}
    }
}