using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Equipment;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Equipment
{
    public class AddEquipmentHandler : IRequestHandler<AddEquipmentRequest, OapEquipment>
    {
        private IOapEquipmentService EquipmentService { get; set; }

        public AddEquipmentHandler(IOapEquipmentService equipmentService)
        {
            EquipmentService = equipmentService;
        }

        Task<OapEquipment> IRequestHandler<AddEquipmentRequest, OapEquipment>.Handle(AddEquipmentRequest request, CancellationToken cancellationToken)
        {
            var existingEquipment = EquipmentService.Get(request.Equipment.Id); 
            if (existingEquipment != null)
            {     
                return Task.FromResult((OapEquipment) null);
            }

            int newEquipmentId = 0;
            using (var ts = new TransactionScope())
            {
                newEquipmentId = EquipmentService.Add(request.Equipment);

                ts.Complete();
            }
            return Task.FromResult(EquipmentService.Get(newEquipmentId));
        }
              
    }
}