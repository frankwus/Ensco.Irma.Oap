using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistWorkInstruction
{
    public class AddChecklistWorkInstructionRequest : IRequest<OapChecklistWorkInstruction>
    {
        public AddChecklistWorkInstructionRequest(OapChecklistWorkInstruction checklistWorkInstruction)
        {
            ChecklistWorkInstruction = checklistWorkInstruction;
        }

        public OapChecklistWorkInstruction ChecklistWorkInstruction { get; }
    }
}