using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Equipment
{
    public class DeleteEquipmentRequest : IRequest<bool>
    {
        public DeleteEquipmentRequest(int equipmentId)
        {
            EquipmentId = equipmentId;
        }

        public int EquipmentId { get; }
    }
}