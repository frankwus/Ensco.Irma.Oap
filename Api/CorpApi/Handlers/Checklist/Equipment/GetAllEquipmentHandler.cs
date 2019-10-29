using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Equipment;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Equipment
{
    public class GetAllEquipmentHandler : IRequestHandler<GetAllEquipmentRequest, IEnumerable<OapEquipment>>
    {
        private IOapEquipmentService EquipmentService { get; set; }

        public GetAllEquipmentHandler(IOapEquipmentService equipmentService)
        {
            EquipmentService = equipmentService;
        }
        Task<IEnumerable<OapEquipment>> IRequestHandler<GetAllEquipmentRequest, IEnumerable<OapEquipment>>.Handle(GetAllEquipmentRequest request, CancellationToken cancellationToken)
        {
            var list = EquipmentService.GetAll();
            return Task.FromResult(list);
        }

    }
}