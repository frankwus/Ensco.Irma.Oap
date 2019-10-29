using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    public class OapChecklistLayoutColumnRepository : BaseRepository<IrmaOapDbContext, OapChecklistLayoutColumn, int>, IOapChecklistLayoutColumnRepository
    {
        public OapChecklistLayoutColumnRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        public IEnumerable<OapChecklistLayoutColumn> GetAll(int layoutId)
        {
            return AllItems.Where(it => it.ChecklistLayoutId == layoutId).ToList();
        }
    }

}
