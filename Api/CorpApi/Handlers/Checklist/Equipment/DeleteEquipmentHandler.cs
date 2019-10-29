using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Equipment;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Equipment
{
    public class DeleteEquipmentHandler : IRequestHandler<DeleteEquipmentRequest, bool>
    {
        private IOapEquipmentService EquipmentService { get; set; }

        public DeleteEquipmentHandler(IOapEquipmentService equipmentService)
        {
            EquipmentService = equipmentService;
        }


        Task<bool> IRequestHandler<DeleteEquipmentRequest, bool>.Handle(DeleteEquipmentRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var EquipmentId = EquipmentService.Get(request.EquipmentId);

                EquipmentService.Delete(EquipmentId);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}