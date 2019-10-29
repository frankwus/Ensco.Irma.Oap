using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IRigOapChecklistRepository : IBaseIdRepository<RigOapChecklist, Guid>
    {
        IEnumerable<RigOapChecklist> GetAll(string status);

        IEnumerable<RigOapChecklist> GetAll(string status, DateTime checklistDate);

        RigOapChecklist GetCompleteChecklist(Guid rigCheckListId);

        RigOapChecklist GetLastChecklistWithQuestions(int checklistId, DateTime currentChecklistDate);

        IEnumerable<RigOapChecklist> GetGetAllActiveChecklistsWithNoQuestions(int checklistId);

        IEnumerable<RigOapChecklist> GetByTypeSubTypeFormType(string typeName, string subtypeName, string formType, string status);

        IEnumerable<RigOapChecklist> GetByTypeSubTypeCodeFormType(string typeCode, string subtypeCode, string formType, string status);

        IEnumerable<RigOapChecklist> GetByTypeSubType(string typeName, string subtypeName, string status);

        IEnumerable<RigOapChecklist> GetByTypeSubTypeCode(string typeCode, string subtypeCode, string status);       

        IEnumerable<RigOapChecklist> GetOpenFsoChecklist(int fsoChecklistId);

        RigOapChecklist GetByUniqueId(int id);

        IEnumerable<RigOapChecklist> GetFsoChecklistByMinDate(DateTime minDate, int oapChecklistId);

        IQueryable<RigOapChecklist> GetQueryable(Expression<Func<RigOapChecklist, bool>> expression);

        IEnumerable<RigOapChecklist> GetAllChecklistsByChecklistId(int checklistId, DateTime fromDate, DateTime toDate);      

    }
}
