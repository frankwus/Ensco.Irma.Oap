using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    public class OapChecklistLayoutRepository : BaseRepository<IrmaOapDbContext, OapChecklistLayout, int>, IOapChecklistLayoutRepository
    {
        public OapChecklistLayoutRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        protected override IQueryable<OapChecklistLayout> AllItems => Items.Include(p => p.Columns);
    }

}
