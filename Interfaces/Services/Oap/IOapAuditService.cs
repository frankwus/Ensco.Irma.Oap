using System.Collections.Generic;
using Ensco.Irma.Interfaces.Domain;
using System;
using Ensco.Irma.Models.Domain.Oap.Audit;
using Ensco.Irma.Models.Domain.Oap;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IOapAuditService : IHistoricalEntityIdService<OapAudit, int>
    {

        IEnumerable<OapAudit> GetAllByStatus(string status);
        OapAudit GetAudit(int id);
        RigChecklistValidationResult ValidateAuditProtocols(int auditId);
    }

   
}
