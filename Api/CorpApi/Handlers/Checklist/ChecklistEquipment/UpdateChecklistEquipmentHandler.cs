using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistEquipment;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ChecklistEquipment
{
    public class UpdateChecklistEquipmentHandler : IRequestHandler<UpdateChecklistEquipmentRequest, bool>
    {
        private IOapChecklistEquipmentService EquipmentService { get; set; }  
        private IMapper Mapper { get; set; }
        public UpdateChecklistEquipmentHandler(IOapChecklistEquipmentService equipmentService, IMapper mapper)
        {
            EquipmentService = equipmentService;
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateChecklistEquipmentRequest, bool>.Handle(UpdateChecklistEquipmentRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistEquipment = EquipmentService.Get(request.ChecklistEquipment.Id);

            if (existingChecklistEquipment == null)
            {
                throw new ApplicationException($"UpdateChecklistEquipmentHandler: ChecklistEquipment with Id {request.ChecklistEquipment.Id} does not exist.");
            }

            //var checkDuplicate = EquipmentService.GetEquipmentByChecklistAndRigId(request.ChecklistEquipment.RigId, request.ChecklistEquipment.OapChecklistId, request.ChecklistEquipment.OapEquipmentId);
            //if (checkDuplicate != null)
            //{
            //    throw new ApplicationException($"UpdateChecklistEquipmentHandler: ChecklistEquipment with Id {request.ChecklistEquipment.Id} already exist.");
            //}

            //AutoMapper to Map the fields 
            Mapper.Map(request.ChecklistEquipment, existingChecklistEquipment);

            using (var ts = new TransactionScope())
            {
                var updatedChecklistEquipment = EquipmentService.Update(existingChecklistEquipment);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}