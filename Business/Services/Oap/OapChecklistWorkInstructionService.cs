using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Services.Oap
{
    public class OapChecklistWorkInstructionService : HistoricalEntityIdService<IrmaOapDbContext, IOapChecklistWorkInstructionRepository, OapChecklistWorkInstruction, int>, IOapChecklistWorkInstructionService
    {
        public OapChecklistWorkInstructionService(IOapChecklistWorkInstructionRepository repository) : base(repository)
        {
        }

        public IEnumerable<OapChecklistWorkInstruction> GetAllWorkInstructionByChecklistAndRigId(string rigId, int oapChecklistId)
        {
            return Repository.GetAllWorkInstructionByChecklistAndRigId(rigId, oapChecklistId);
        }

        public OapChecklistWorkInstruction GetWorkInstructionByChecklistAndRigId(string rigId, int oapChecklistId, int oapWorkInstructionId)
        {
            return Repository.GetWorkInstructionByChecklistAndRigId(rigId, oapChecklistId, oapWorkInstructionId);
        }
    }
}
