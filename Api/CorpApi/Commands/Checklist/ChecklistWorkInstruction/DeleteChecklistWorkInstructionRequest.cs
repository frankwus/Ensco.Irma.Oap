using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistWorkInstruction
{
    public class DeleteChecklistWorkInstructionRequest : IRequest<bool>
    {
        public DeleteChecklistWorkInstructionRequest(int checklistWorkInstructionId)
        {
            ChecklistWorkInstructionId = checklistWorkInstructionId;
        }

        public int ChecklistWorkInstructionId { get; set; }
    }
}