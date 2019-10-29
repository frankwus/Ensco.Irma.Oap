using System.Data.Entity;
using System.Linq;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Data.Repositories
{
    public class OapChecklistGroupRepository : HistoricalBaseRepository<IrmaOapDbContext, OapChecklistGroup, int>, IOapChecklistGroupRepository
    {
        public OapChecklistGroupRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        protected override IQueryable<OapChecklistGroup> AllItems => Items.Include(p => p.SubGroups);       
    }

}
