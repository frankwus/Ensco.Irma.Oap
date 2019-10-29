using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Data.Repositories
{
    public class OapChecklistWorkInstructionRepository : HistoricalBaseIdRepository<IrmaOapDbContext, OapChecklistWorkInstruction, int>, IOapChecklistWorkInstructionRepository
    {
        public OapChecklistWorkInstructionRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        protected override IQueryable<OapChecklistWorkInstruction> AllItems => Items.Include(p => p.OapWorkInstruction);

        public IEnumerable<OapChecklistWorkInstruction> GetAllWorkInstructionByChecklistAndRigId(string rigId, int oapChecklistId)
        {
            var today = DateTime.UtcNow;

            return (from it in AllItems
             where it.RigId == rigId
             && it.OapChecklistId == oapChecklistId 
             && it.StartDateTime <= today
             && it.EndDateTime > today
             select it).ToList();
        }

        public OapChecklistWorkInstruction GetWorkInstructionByChecklistAndRigId(string rigId, int oapChecklistId, int oapWorkInstructionId)
        {
            var today = DateTime.UtcNow;

            return (from it in AllItems                                     
                   where it.RigId == rigId
                   && it.OapChecklistId == oapChecklistId
                   && it.OapWorkInstructionId == oapWorkInstructionId
                   && it.StartDateTime <= today
                   && it.EndDateTime > today
                   select it).FirstOrDefault() ;
        }

    }

}
