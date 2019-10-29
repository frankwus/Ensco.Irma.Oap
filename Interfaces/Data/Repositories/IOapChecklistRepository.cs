using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IOapChecklistRepository : IHistoricalBaseRepository<OapChecklist, int>
    {
        IEnumerable<OapChecklist> GetByTypeSubTypeFormType(string typeName, string subTypeName, string formType);

        IEnumerable<OapChecklist> GetByTypeSubTypeCodeFormType(string typeCode, string subTypeCode, string formType);

        IEnumerable<OapChecklist> GetByTypeSubType(string typeName, string subTypeName);

        IEnumerable<OapChecklist> GetByTypeSubTypeCode(string typeCode, string subTypeCode);

        OapChecklist GetByTitle(string title);

        OapChecklist GetCompleteChecklist(int checklistId);

        IEnumerable<OapChecklist> GetByTypeName(string typeName);
    }
}
