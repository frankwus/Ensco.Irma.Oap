using System.Data.Entity;
using System.Linq;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Data.Repositories
{
    public class OapChecklistSubGroupRepository : HistoricalBaseRepository<IrmaOapDbContext, OapChecklistSubGroup, int>, IOapChecklistSubGroupRepository
    {
        public OapChecklistSubGroupRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        public OapChecklistSubGroup GetBySubGroupName(int groupId, string name)
        {
            return AllItems.FirstOrDefault ( sg => sg.OapChecklistGroupId == groupId && sg.Name.Equals(name));
        }
    }

}
