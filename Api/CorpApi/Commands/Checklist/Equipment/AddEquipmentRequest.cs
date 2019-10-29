using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Equipment
{
    public class AddEquipmentRequest : IRequest<OapEquipment>
    {
        public AddEquipmentRequest(OapEquipment equipment)
        {
            Equipment = equipment;
        }

        public OapEquipment Equipment { get; }
    }
}