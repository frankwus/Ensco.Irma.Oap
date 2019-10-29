using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IOapChecklistEquipmentRepository : IHistoricalBaseIdRepository<OapChecklistEquipment, int>
    {
        OapChecklistEquipment GetEquipmentByChecklistAndRigId(string rigId, int oapChecklistId, int oapEquipmentId);
    }
}
