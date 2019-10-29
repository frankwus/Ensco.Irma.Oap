using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapChecklistEquipmentService : HistoricalEntityIdService<IrmaOapDbContext, IOapChecklistEquipmentRepository, OapChecklistEquipment, int>, IOapChecklistEquipmentService
    {
        public OapChecklistEquipmentService(IOapChecklistEquipmentRepository repository) : base(repository)
        {
             
        }

        public OapChecklistEquipment GetEquipmentByChecklistAndRigId(string rigId, int oapChecklistId, int oapEquipmentId)
        {
            return Repository.GetEquipmentByChecklistAndRigId(rigId, oapChecklistId, oapEquipmentId);
        }
    }
}
