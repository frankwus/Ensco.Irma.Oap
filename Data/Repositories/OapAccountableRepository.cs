using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Data.Repositories
{
    public class OapAccountableRepository : HistoricalBaseIdRepository<IrmaOapDbContext, OapAccountable, int>, IOapAccountableRepository
    {
        public OapAccountableRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {
        }

        public IEnumerable<OapAccountable> GetAllByPositionIds(int[] ids)
        {
            return AllItems.Where(a => ids.Contains(a.PositionId)).ToList();
        }
    }
}
