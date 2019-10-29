using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Asset;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class GetAllRigOapChecklistGroupAssetHandler : IRequestHandler<GetAllRigOapChecklistGroupAssetRequest, IEnumerable<RigOapChecklistGroupAsset>>
    {
        private IRigOapChecklistGroupAssetService RigOapChecklistGroupAssetService { get; set; }

        public GetAllRigOapChecklistGroupAssetHandler(IRigOapChecklistGroupAssetService rigOapChecklistGroupAssetService)
        {
            RigOapChecklistGroupAssetService = rigOapChecklistGroupAssetService;
        }

        Task<IEnumerable<RigOapChecklistGroupAsset>> IRequestHandler<GetAllRigOapChecklistGroupAssetRequest, IEnumerable<RigOapChecklistGroupAsset>>.Handle(GetAllRigOapChecklistGroupAssetRequest request, CancellationToken cancellationToken)
        {
            var cl =  RigOapChecklistGroupAssetService.GetAll();
            return Task.FromResult(cl);
        }
    }
}