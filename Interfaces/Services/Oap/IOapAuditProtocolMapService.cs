using System.Collections.Generic;
using Ensco.Irma.Interfaces.Domain;
using System;
using Ensco.Irma.Models.Domain.Oap.Audit;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IOapAuditProtocolMapService : IEntityIdService<OapAuditProtocol, int>
    {
        IEnumerable<RigOapChecklist> GetProtocolsByAuditId(int auditId);
    }   
}
