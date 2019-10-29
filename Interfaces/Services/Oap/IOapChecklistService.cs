using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IOapChecklistService  : IHistoricalEntityService<OapChecklist, int>
    {
        
        IEnumerable<OapChecklist> GetByTypeSubType(string typeName, string subTypeName);


        IEnumerable<OapChecklist> GetByTypeSubTypeCode(string typeCode, string subTypeCode);

        IEnumerable<OapChecklist> GetByTypeSubTypeFormType(string typeName, string subTypeName, string formType);

        IEnumerable<OapChecklist> GetByTypeSubTypeCodeFormType(string typeCode, string subTypeCode, string formType);

        OapChecklist GetByTitle(string title);

        IEnumerable<OapChecklist> GetAllAuditProtocols();

        IEnumerable<OapChecklist> GetByTypeName(string typeName);
    }
}
