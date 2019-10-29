using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IOapChecklistAssetDataManagementService : IEntityIdService<OapAssetDataManagement, int>
    {
        IEnumerable<OapAssetDataManagement> GetAssetsByGroup(int groupId);
    }
}
