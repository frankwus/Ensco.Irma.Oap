using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistEquipment;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ChecklistEquipment
{
    public class GetAllChecklistEquipmentHandler : IRequestHandler<GetAllChecklistEquipmentRequest, IEnumerable<OapChecklistEquipment>>
    {

        private IOapChecklistEquipmentService EquipmentService { get; set; }

        public GetAllChecklistEquipmentHandler(IOapChecklistEquipmentService equipmentService)
        {
            EquipmentService = equipmentService;
        }


        Task<IEnumerable<OapChecklistEquipment>> IRequestHandler<GetAllChecklistEquipmentRequest, IEnumerable<OapChecklistEquipment>>.Handle(GetAllChecklistEquipmentRequest request, CancellationToken cancellationToken)
        {
            var checklistEquipments = EquipmentService.GetAll();  
            return Task.FromResult(checklistEquipments);
        }
    }
}