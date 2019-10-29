using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Asset
{
    public class DeleteRigOapChecklistGroupAssetRequest : IRequest<bool>
    { 
        public DeleteRigOapChecklistGroupAssetRequest(Guid assetId)
        {
            AssetId = assetId;
        }

        public Guid  AssetId {get; set;}
    }
}