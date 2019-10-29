using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistEquipment;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ChecklistEquipment
{
    public class DeleteChecklistEquipmentHandler : IRequestHandler<DeleteChecklistEquipmentRequest, bool>
    {
        private IOapChecklistEquipmentService EquipmentService { get; set; }

        public DeleteChecklistEquipmentHandler(IOapChecklistEquipmentService equipmentService)
        {
            EquipmentService = equipmentService;
        }


        Task<bool> IRequestHandler<DeleteChecklistEquipmentRequest, bool>.Handle(DeleteChecklistEquipmentRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var ChecklistEquipmentId = EquipmentService.Get(request.ChecklistEquipmentId);

                EquipmentService.Delete(ChecklistEquipmentId);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}