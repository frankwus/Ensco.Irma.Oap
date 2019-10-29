using System.Data.Entity;
using System.Linq;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Data.Repositories
{
    public class OapChecklistCommentRepository : HistoricalBaseIdRepository<IrmaOapDbContext, OapChecklistComment, int>, IOapChecklistCommentRepository
    {
        public OapChecklistCommentRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }
    }
}
