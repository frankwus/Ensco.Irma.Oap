using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist.AssetDataManagement;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.AssetDataManagement
{
    public class GetAllChecklistAssetDataManagementHandler : IRequestHandler<GetAllChecklistAssetDataManagementRequest, IEnumerable<OapAssetDataManagement>>
    {

        private IOapChecklistAssetDataManagementService AssetDataManagementService { get; set; }

        public GetAllChecklistAssetDataManagementHandler(IOapChecklistAssetDataManagementService assetDataManagementService)
        {
            AssetDataManagementService = assetDataManagementService;
        }

        Task<IEnumerable<OapAssetDataManagement>> IRequestHandler<GetAllChecklistAssetDataManagementRequest, IEnumerable<OapAssetDataManagement>>.Handle(GetAllChecklistAssetDataManagementRequest request, CancellationToken cancellationToken)
        {
            var admChecklist = AssetDataManagementService.GetAll();
            return Task.FromResult(admChecklist);
        }
    }
}