using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.WorkInstruction
{
    public class UpdateWorkInstructionRequest : IRequest<bool>
    {
        public UpdateWorkInstructionRequest(OapWorkInstruction workInstruction)
        {
            WorkInstruction = workInstruction;
        }

        public OapWorkInstruction WorkInstruction { get; }
    }
}