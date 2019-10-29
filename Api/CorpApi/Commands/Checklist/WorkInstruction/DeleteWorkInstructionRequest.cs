using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.WorkInstruction
{
    public class DeleteWorkInstructionRequest : IRequest<bool>
    {
        public DeleteWorkInstructionRequest(int workInstructionId)
        {
            WorkInstructionId = workInstructionId;
        }

        public int WorkInstructionId { get; }
    }
}