using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistEquipment;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ChecklistEquipment
{
    public class AddChecklistEquipmentHandler : IRequestHandler<AddChecklistEquipmentRequest, OapChecklistEquipment>
    {
        private IOapChecklistEquipmentService EquipmentService { get; set; }

        public AddChecklistEquipmentHandler(IOapChecklistEquipmentService equipmentService)
        {
            EquipmentService = equipmentService;
        }

        Task<OapChecklistEquipment> IRequestHandler<AddChecklistEquipmentRequest, OapChecklistEquipment>.Handle(AddChecklistEquipmentRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistEquipment = EquipmentService.GetEquipmentByChecklistAndRigId(request.ChecklistEquipment.RigId.ToString(), request.ChecklistEquipment.OapChecklistId, request.ChecklistEquipment.OapEquipmentId);

            if (existingChecklistEquipment != null)
            {
                return Task.FromResult((OapChecklistEquipment)null);
            }

            int newChecklistEquipmentId = 0;
            using (var ts = new TransactionScope())
            {
                newChecklistEquipmentId = EquipmentService.Add(request.ChecklistEquipment);

                ts.Complete();
            }
            return Task.FromResult(EquipmentService.Get(newChecklistEquipmentId));
        }
    }
}