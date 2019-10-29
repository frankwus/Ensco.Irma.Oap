using System.Data.Entity;
using System.Linq;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Data.Repositories
{
    public class OapFrequencyRepository : HistoricalBaseRepository<IrmaOapDbContext, OapFrequency, int> , IOapFrequencyRepository
    {
        public OapFrequencyRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }
    }

}
