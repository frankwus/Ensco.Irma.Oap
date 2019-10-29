using Ensco.Irma.Models.Domain.Oap.Audit;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IOapAuditRepository: IHistoricalBaseIdRepository<OapAudit, int>
    {
        //  IEnumerable<OapAudit> GetAll(string status="Open");
        //OapAudit GetByName(string Name);
        IEnumerable<OapAudit> GetAllByStatus(string status);
        OapAudit GetCompleteAudit(int auditId);
    }
}
