using System;
using System.Data.Entity;
using System.Linq;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Data.Repositories
{
    public class OapChecklistEquipmentRepository : HistoricalBaseIdRepository<IrmaOapDbContext, OapChecklistEquipment, int>, IOapChecklistEquipmentRepository
    {
        public OapChecklistEquipmentRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        protected override IQueryable<OapChecklistEquipment> AllItems =>Items.Include(p => p.OapEquipment);

        public OapChecklistEquipment GetEquipmentByChecklistAndRigId(string rigId, int oapChecklistId, int oapEquipmentId)
         {
            var today = DateTime.UtcNow;

            return (from it in AllItems
                    where it.RigId == rigId
                    && it.OapChecklistId == oapChecklistId
                    && it.OapEquipmentId == oapEquipmentId
                    && it.StartDateTime <= today
                    && it.EndDateTime > today
                    select it).FirstOrDefault();
        }


    }

}
