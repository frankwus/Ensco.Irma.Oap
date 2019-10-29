using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist.AssetDataManagement;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.AssetDataManagement
{
    public class AddChecklistAssetDataManagementHandler : IRequestHandler<AddChecklistAssetDataManagementRequest, OapAssetDataManagement>
    {
        private IOapChecklistAssetDataManagementService AssetDataManagementService { get; set; }

        public AddChecklistAssetDataManagementHandler(IOapChecklistAssetDataManagementService assetDataManagementService)
        {
            AssetDataManagementService = assetDataManagementService;
        }

        Task<OapAssetDataManagement> IRequestHandler<AddChecklistAssetDataManagementRequest, OapAssetDataManagement>.Handle(AddChecklistAssetDataManagementRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistAssetDataManagement = AssetDataManagementService.Get(request.AssetDataManagementChecklist.Id);   
            if (existingChecklistAssetDataManagement != null)
            {
                return Task.FromResult((OapAssetDataManagement)null);
            }

            int newChecklistAssetDataManagementId = 0;
            using (var ts = new TransactionScope())
            {
                newChecklistAssetDataManagementId = AssetDataManagementService.Add(request.AssetDataManagementChecklist);

                ts.Complete();
            }

            return Task.FromResult(AssetDataManagementService.Get(newChecklistAssetDataManagementId));
        }
    }
}