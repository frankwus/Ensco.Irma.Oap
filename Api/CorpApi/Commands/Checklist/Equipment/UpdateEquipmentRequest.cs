using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Equipment
{
    public class UpdateEquipmentRequest : IRequest<bool>
    {
        public UpdateEquipmentRequest(OapEquipment equipment)
        {
            Equipment = equipment;
        }

        public OapEquipment Equipment { get; }
    }
}