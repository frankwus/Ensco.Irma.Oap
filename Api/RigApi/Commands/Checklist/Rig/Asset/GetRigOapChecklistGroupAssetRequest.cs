using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Asset
{
    public class GetRigOapChecklistGroupAssetRequest : IRequest<RigOapChecklistGroupAsset>
    { 
        public GetRigOapChecklistGroupAssetRequest(Guid rigOapChecklistAssetId)
        {
            RigOapChecklistGroupAssetId = rigOapChecklistAssetId;
        }

        public Guid RigOapChecklistGroupAssetId { get; set; }
    }
}