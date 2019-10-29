using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistEquipment
{
    public class AddChecklistEquipmentRequest : IRequest<OapChecklistEquipment>
    {
        public AddChecklistEquipmentRequest(OapChecklistEquipment checklistEquipment)
        {
            ChecklistEquipment = checklistEquipment;
        }

        public OapChecklistEquipment ChecklistEquipment { get; }
    }
}