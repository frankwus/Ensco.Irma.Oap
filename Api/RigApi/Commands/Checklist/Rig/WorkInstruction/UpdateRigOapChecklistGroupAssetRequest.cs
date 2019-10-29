using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.WorkInstruction
{
    public class UpdateRigOapChecklistWorkInstructionRequest : IRequest<RigOapChecklistWorkInstruction>
    {
        public UpdateRigOapChecklistWorkInstructionRequest(RigOapChecklistWorkInstruction checklistWorkInstruction)
        {
            RigChecklistWorkInstruction = checklistWorkInstruction;
        }

        public RigOapChecklistWorkInstruction RigChecklistWorkInstruction { get;  }
    }
}