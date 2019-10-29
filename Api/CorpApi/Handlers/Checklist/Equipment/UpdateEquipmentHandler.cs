using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Equipment;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Equipment
{
    public class UpdateEquipmentHandler : IRequestHandler<UpdateEquipmentRequest, bool>
    { 
        private IOapEquipmentService EquipmentService { get; set; }
        private IMapper Mapper { get; set; }
        public UpdateEquipmentHandler(IOapEquipmentService equipmentService, IMapper mapper)
        {
            EquipmentService = equipmentService;
            Mapper = mapper;
        }
        
        Task<bool> IRequestHandler<UpdateEquipmentRequest, bool>.Handle(UpdateEquipmentRequest request, CancellationToken cancellationToken)
        {
            var existingEquipment = EquipmentService.Get(request.Equipment.Name);

            if (existingEquipment == null)
            {
                throw new ApplicationException($"UpdateEquipmentHandler: Equipment with Name {request.Equipment.Name} does not exist.");
            }

            var checkDuplicate = EquipmentService.Get(request.Equipment);
            if (checkDuplicate != null )
            {
                throw new ApplicationException($"UpdateEquipmentHandler: Equipment with Name {request.Equipment.Name} already exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.Equipment, existingEquipment);

            using (var ts = new TransactionScope())
            {
                var updatedQuestionTagMap = EquipmentService.Update(existingEquipment);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}