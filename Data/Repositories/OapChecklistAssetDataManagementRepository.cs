using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Data.Repositories
{
    public class OapChecklistAssetDataManagementRepository : BaseIdRepository<IrmaOapDbContext, OapAssetDataManagement, int>, IOapChecklistAssetDataManagementRepository
    {
        public OapChecklistAssetDataManagementRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        protected override IQueryable<OapAssetDataManagement> AllItems => Items.Include(p => p.OapSubSystem);

        public IEnumerable<OapAssetDataManagement> GetAssetsByGroup(int groupId)
        {
            return (from it in AllItems                                 
                                .Include(a => a.OapSubSystem.OapSystem.SystemGroup) 
                    where it.OapChecklistGroupId == groupId
                    select it).ToList();
        }
    }

}
