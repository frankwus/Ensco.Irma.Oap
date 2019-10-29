using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IOapChecklistAssetDataManagementRepository : IBaseIdRepository<OapAssetDataManagement, int>
    {
        IEnumerable<OapAssetDataManagement> GetAssetsByGroup(int groupId);
    }

    
}
