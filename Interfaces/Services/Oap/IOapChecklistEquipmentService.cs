using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IOapChecklistEquipmentService : IHistoricalEntityIdService<OapChecklistEquipment, int>
    {
        OapChecklistEquipment GetEquipmentByChecklistAndRigId(string rigId, int oapChecklistId, int oapEquipmentId);
    }
}
