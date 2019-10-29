using System;
using System.Collections.Generic;
using System.Linq;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapChecklistService : HistoricalEntityService<IrmaOapDbContext, IOapChecklistRepository, OapChecklist, int>, IOapChecklistService
    {
        public OapChecklistService(IOapChecklistRepository repository) : base(repository)
        {

        }

        public OapChecklist GetByTitle(string title)
        {
            return Repository.GetByTitle(title);
        }

        public IEnumerable<OapChecklist> GetByTypeSubType(string typeName, string subTypeName)
        {
            return Repository.GetByTypeSubType(typeName, subTypeName);
        }

        public IEnumerable<OapChecklist> GetByTypeSubTypeCode(string typeCode, string subTypeCode)
        {
            return Repository.GetByTypeSubTypeCode(typeCode, subTypeCode);
        }

        public IEnumerable<OapChecklist> GetByTypeSubTypeFormType(string typeName, string subTypeName, string formType)
        {
            return Repository.GetByTypeSubTypeFormType(typeName, subTypeName, formType);
        }

        public IEnumerable<OapChecklist> GetByTypeSubTypeCodeFormType(string typeCode, string subTypeCode, string formType)
        {
            var checklist = Repository.GetByTypeSubTypeCodeFormType(typeCode, subTypeCode, formType).ToList();
            return checklist;
        }

        public IEnumerable<OapChecklist> GetAllAuditProtocols()
        {
            var checklist = Repository.GetAll().ToList();

            checklist = checklist.Where(c => c.OapTypeId == 5 || c.OapTypeId == 6 || c.OapTypeId == 8).ToList();

            return checklist;


        }

        public IEnumerable<OapChecklist> GetByTypeName(string typeName)
        {
            return Repository.GetByTypeName(typeName);
        }
    }
}
