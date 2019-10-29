using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistWorkInstruction
{
    public class UpdateChecklistWorkInstructionRequest : IRequest<bool>
    {
        public UpdateChecklistWorkInstructionRequest(OapChecklistWorkInstruction checklistWorkInstruction)
        {
            ChecklistWorkInstruction = checklistWorkInstruction;
        }

        public OapChecklistWorkInstruction ChecklistWorkInstruction { get; }
    }
}