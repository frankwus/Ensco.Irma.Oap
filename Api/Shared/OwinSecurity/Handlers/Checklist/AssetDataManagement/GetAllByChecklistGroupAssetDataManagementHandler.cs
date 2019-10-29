using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist.AssetDataManagement;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.AssetDataManagement
{
    public class GetAllByChecklistGroupAssetDataManagementHandler : IRequestHandler<GetAllByChecklistGroupAssetDataManagementRequest, IEnumerable<OapAssetDataManagement>>
    {

        private IOapChecklistAssetDataManagementService AssetDataManagementService { get; set; }

        public GetAllByChecklistGroupAssetDataManagementHandler(IOapChecklistAssetDataManagementService assetDataManagementService)
        {
            AssetDataManagementService = assetDataManagementService;
        }

        Task<IEnumerable<OapAssetDataManagement>> IRequestHandler<GetAllByChecklistGroupAssetDataManagementRequest, IEnumerable<OapAssetDataManagement>>.Handle(GetAllByChecklistGroupAssetDataManagementRequest request, CancellationToken cancellationToken)
        {
            var admChecklist = AssetDataManagementService.GetAssetsByGroup(request.GroupId);
            return Task.FromResult(admChecklist);
        }
    }
}