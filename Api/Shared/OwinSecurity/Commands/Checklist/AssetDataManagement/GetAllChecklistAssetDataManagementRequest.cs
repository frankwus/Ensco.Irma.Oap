using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.AssetDataManagement
{
    public class GetAllChecklistAssetDataManagementRequest : IRequest<IEnumerable<OapAssetDataManagement>>
    { 
        public GetAllChecklistAssetDataManagementRequest()
        {
           
        }

        //public int AdmChecklistId { get; set; }
    }
}