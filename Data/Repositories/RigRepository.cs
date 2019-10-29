using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    public class RigRepository : BaseRepository<IrmaDbContext, Rig, int>, IRigRespository
    {
        public RigRepository(IIrmaOapDbContext context, ILog log) : base((IrmaDbContext)context, log)
        {

        }
    }
}
