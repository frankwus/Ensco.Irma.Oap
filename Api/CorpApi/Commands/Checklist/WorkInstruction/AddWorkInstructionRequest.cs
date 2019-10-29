using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.WorkInstruction
{
    public class AddWorkInstructionRequest : IRequest<OapWorkInstruction>
    {
        public AddWorkInstructionRequest(OapWorkInstruction workInstruction)
        {
            WorkInstruction = workInstruction;
        }

        public OapWorkInstruction WorkInstruction { get; }
    }
}