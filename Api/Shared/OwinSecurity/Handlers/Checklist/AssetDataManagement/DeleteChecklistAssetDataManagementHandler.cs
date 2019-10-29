using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist.AssetDataManagement; 
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.AssetDataManagement
{
    public class DeleteChecklistAssetDataManagementHandler : IRequestHandler<DeleteChecklistAssetDataManagementRequest, bool>
    {
        private IOapChecklistAssetDataManagementService AssetDataManagementService { get; set; }

        public DeleteChecklistAssetDataManagementHandler(IOapChecklistAssetDataManagementService assetDataManagementService)
        {
            AssetDataManagementService = assetDataManagementService;
        }

        Task<bool> IRequestHandler<DeleteChecklistAssetDataManagementRequest, bool>.Handle(DeleteChecklistAssetDataManagementRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var AdmChecklistId = AssetDataManagementService.Get(request.AdmChecklistId);

                AssetDataManagementService.Delete(AdmChecklistId);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}