using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Asset
{
    public class AddRigOapChecklistGroupAssetRequest : IRequest<RigOapChecklistGroupAsset>
    {
        public AddRigOapChecklistGroupAssetRequest(RigOapChecklistGroupAsset asset)
        {
            Asset = asset;
        }

        public RigOapChecklistGroupAsset Asset { get;  }
    }
}