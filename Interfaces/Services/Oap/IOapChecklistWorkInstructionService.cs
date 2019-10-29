using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IOapChecklistWorkInstructionService : IHistoricalEntityIdService<OapChecklistWorkInstruction, int>
    {
        OapChecklistWorkInstruction GetWorkInstructionByChecklistAndRigId(string rigId, int oapChecklistId, int oapWorkInstructionId);

        IEnumerable<OapChecklistWorkInstruction> GetAllWorkInstructionByChecklistAndRigId(string rigId, int oapChecklistId);
    }
}
