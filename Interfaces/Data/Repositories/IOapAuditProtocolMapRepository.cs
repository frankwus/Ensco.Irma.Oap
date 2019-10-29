using Ensco.Irma.Models.Domain.Oap.Audit;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IOapAuditProtocolMapRepository : IBaseIdRepository<OapAuditProtocol, int>
    {
        //Get protocols from mapping table
        IEnumerable<RigOapChecklist> GetProtocolsByAuditId(int auditId); 
    }
}
