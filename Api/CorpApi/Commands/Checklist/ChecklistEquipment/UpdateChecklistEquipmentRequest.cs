using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistEquipment
{
    public class UpdateChecklistEquipmentRequest : IRequest<bool>
    {
        public UpdateChecklistEquipmentRequest(OapChecklistEquipment checklistEquipment)
        {
            ChecklistEquipment = checklistEquipment;
        }

        public OapChecklistEquipment ChecklistEquipment { get; }
    }
}