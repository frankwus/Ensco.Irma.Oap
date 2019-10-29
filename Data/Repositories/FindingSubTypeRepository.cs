using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    public class FindingSubTypeRepository : BaseRepository<IrmaOapDbContext, FindingSubType, int>, IFindingSubTypeRepository
    {
        public FindingSubTypeRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }
    }
}
