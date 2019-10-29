using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.WorkInstruction
{
    public class AddRigOapChecklistWorkInstructionRequest : IRequest<RigOapChecklistWorkInstruction>
    {
        public AddRigOapChecklistWorkInstructionRequest(RigOapChecklistWorkInstruction workInstruction)
        {
            WorkInstruction = workInstruction;
        }

        public RigOapChecklistWorkInstruction WorkInstruction { get;  }
    }
}