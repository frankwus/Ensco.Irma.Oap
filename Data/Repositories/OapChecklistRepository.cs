using Ensco.Irma.Data.Context;
using Ensco.Irma.Data.Repositories;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    public class OapChecklistRepository : HistoricalBaseRepository<IrmaOapDbContext, OapChecklist, int>, IOapChecklistRepository
    {
        public OapChecklistRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        protected override IQueryable<OapChecklist> AllItems => Items.Include(c => c.OapType).Include(c => c.OapSubType).Include(c => c.OapFrequencyType).Include(cl => cl.Groups);

        public OapChecklist GetByTitle(string title)
        {
            return Items.FirstOrDefault(c => c.Name.Equals(title, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<OapChecklist> GetByTypeSubType(string typeName, string subTypeName)
        {
            if (typeName.Equals("All", StringComparison.InvariantCultureIgnoreCase) && subTypeName.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                return GetAll();
            }

            return AllItems.Where(c => c.OapType.Name.Equals(typeName, StringComparison.InvariantCultureIgnoreCase)
                   && subTypeName.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapSubType.Name.Equals(subTypeName, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<OapChecklist> GetByTypeSubTypeCode(string typeCode, string subTypeCode)
        {
            if (typeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase) && subTypeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                return GetAll();
            }

            return AllItems.Where(c => c.OapType.Code.Equals(typeCode, StringComparison.InvariantCultureIgnoreCase)
                            && subTypeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapSubType.Code.Equals(subTypeCode, StringComparison.InvariantCultureIgnoreCase)).Select(c => c);
        }

        public IEnumerable<OapChecklist> GetByTypeSubTypeFormType(string typeName, string subTypeName, string formType)
        {
            if (typeName.Equals("All", StringComparison.InvariantCultureIgnoreCase) && subTypeName.Equals("All", StringComparison.InvariantCultureIgnoreCase) && formType.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                return GetAll();
            }

            return AllItems.Where(c => c.OapType.Name.Equals(typeName, StringComparison.InvariantCultureIgnoreCase)
                            && subTypeName.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapSubType.Name.Equals(subTypeName, StringComparison.InvariantCultureIgnoreCase)
                            && formType.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapProtocolFormType.Name.Equals(formType, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<OapChecklist> GetByTypeSubTypeCodeFormType(string typeCode, string subTypeCode, string formType)
        {
            if (typeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase) && subTypeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase) && formType.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                return GetAll();
            }

            if (!formType.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                return AllItems.Where(c => c.OapProtocolFormType.Name.Equals(formType, StringComparison.InvariantCultureIgnoreCase)
                   && ((typeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapType.Code.Equals(typeCode, StringComparison.InvariantCultureIgnoreCase))
                   && (subTypeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapSubType.Code.Equals(subTypeCode, StringComparison.InvariantCultureIgnoreCase))));
            }

            return GetByTypeSubTypeCode(typeCode, subTypeCode);

        }

        public OapChecklist GetCompleteChecklist(int checklistId)
        {
            return (from it in AllItems.Include(c => c.Comments)
                                   .Include(c => c.Groups)
                                   .Include(c => c.Groups.Select(g => g.OapGraphic))
                                   .Include(c => c.Groups.Select(g => g.SubGroups.Select(sg => sg.Topics.Select(st => st.Questions.Select(q => q.OapChecklistQuestionDataType)))))
                                   .Include(c => c.Groups.Select(g => g.SubGroups.Select(sg => sg.Topics.Select(st => st.Questions.Select(q => q.OapFrequency)))))
                    where it.Id == checklistId
                    select it).FirstOrDefault();
        }

        public IEnumerable<OapChecklist> GetByTypeName(string typeName)
        {
            var hierarchy = Context.OapHierarchies.FirstOrDefault(h => h.Name.ToLower() == typeName.ToLower());
            if (hierarchy == null) return null;

            return Context.OapChecklists.Where(c => c.OapTypeId == hierarchy.Id);
        }
    }
}
