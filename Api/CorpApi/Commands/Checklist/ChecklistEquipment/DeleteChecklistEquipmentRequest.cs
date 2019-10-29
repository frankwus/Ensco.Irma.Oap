using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistEquipment
{
    public class DeleteChecklistEquipmentRequest : IRequest<bool>
    {
        public DeleteChecklistEquipmentRequest(int checklistEquipmentId)
        {
            ChecklistEquipmentId = checklistEquipmentId;
        }

        public int ChecklistEquipmentId { get; set; }
    }
}