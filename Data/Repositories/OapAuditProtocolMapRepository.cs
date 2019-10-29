using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Audit;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    public class OapAuditProtocolMapRepository : BaseIdRepository<IrmaOapDbContext, OapAuditProtocol, int>, IOapAuditProtocolMapRepository
    {
        public OapAuditProtocolMapRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        } 

        public IEnumerable<RigOapChecklist> GetProtocolsByAuditId(int auditId)
        { 
            return (from it in AllItems.Include(a => a.RigOapChecklist)
                                       .Include(a => a.RigOapChecklist.OapChecklist.OapType).Where(a=> a.RigOapChecklist.OapChecklist.OapType.Code != "AR")
                    where it.AuditId == auditId                         
                    select it.RigOapChecklist).ToList();

        }

    }
}
