using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.AssetDataManagement
{
    public class GetAllByChecklistGroupAssetDataManagementRequest : IRequest<IEnumerable<OapAssetDataManagement>>
    { 
        public GetAllByChecklistGroupAssetDataManagementRequest(int groupId)
        {
            GroupId = groupId;
        }

        public int GroupId { get; }

    }
}