using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Asset
{
    public class UpdateRigOapChecklistGroupAssetRequest : IRequest<RigOapChecklistGroupAsset>
    {
        public UpdateRigOapChecklistGroupAssetRequest(RigOapChecklistGroupAsset checklistGroupAsset)
        {
            RigChecklistGroupAsset = checklistGroupAsset;
        }

        public RigOapChecklistGroupAsset RigChecklistGroupAsset { get;  }
    }
}