﻿using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.AssetDataManagement
{
    public class UpdateChecklistAssetDataManagementRequest : IRequest<bool>
    {
        public UpdateChecklistAssetDataManagementRequest(OapAssetDataManagement assetDataManagementChecklist)
        {
            AssetDataManagementChecklist = assetDataManagementChecklist;
        }

        public OapAssetDataManagement AssetDataManagementChecklist { get; }
    }
}