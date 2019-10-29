using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.IRMA;

namespace Ensco.Irma.Data.Repositories
{
    public class CriticalityRepository : BaseRepository<IrmaDbContext, Criticality, int>, ICriticalityRepository
    {
        public CriticalityRepository(IIrmaDbContext context, ILog log) : base((IrmaDbContext) context, log)
        {

        }
    }
}
