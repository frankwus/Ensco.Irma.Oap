using System.Collections.Generic;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapChecklistAssetDataManagementService : EntityIdService<IrmaOapDbContext, IOapChecklistAssetDataManagementRepository, OapAssetDataManagement, int>, IOapChecklistAssetDataManagementService
    {
        public OapChecklistAssetDataManagementService(IOapChecklistAssetDataManagementRepository repository) : base(repository)
        {

        }

        public IEnumerable<OapAssetDataManagement> GetAssetsByGroup(int groupId)
        {
            return Repository.GetAssetsByGroup(groupId);
        }
    }
}
