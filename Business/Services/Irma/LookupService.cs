using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Interfaces.Services.Security;
using Ensco.Irma.Models.Domain.IRMA;

namespace Ensco.Irma.Services.Irma
{
    public class CriticalityService : EntityService<IrmaDbContext, ICriticalityRepository, Criticality, int>, ICriticalityService
    {
        public CriticalityService(ICriticalityRepository repository, ILog log) : base(repository, log)
        { 
        }
    }
}
