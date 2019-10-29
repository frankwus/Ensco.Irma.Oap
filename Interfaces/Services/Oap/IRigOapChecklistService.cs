using Ensco.Irma.Models.Domain.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IRigOapChecklistService : IEntityIdService<RigOapChecklist, Guid>
    {
        IEnumerable<RigOapChecklist> GetAll(string status);

        IEnumerable<RigOapChecklist> GetAll(string status, DateTime startDate);

        RigOapChecklist GetCompleteChecklist(Guid rigCheckListId);

        IEnumerable<RigOapChecklist> GetOpenFsoChecklists(int fsoChecklistId);

        IEnumerable<RigOapChecklist> GetFsoChecklistByMindate(DateTime minDate, int oapChecklistId);

        RigOapChecklist GetByUniqueId(int id);

        IEnumerable<RigOapChecklist> GetByTypeStatus(string typeName, string status);

        IEnumerable<RigOapChecklist> GetByTypeSubType(string typeName, string subTypeName, string status);

        IEnumerable<RigOapChecklist> GetByTypeSubTypeCode(string typeCode, string subTypeCode, string status);

        IEnumerable<RigOapChecklist> GetByTypeSubTypeFormType(string typeName, string subTypeName, string formType, string status);

        IEnumerable<RigOapChecklist> GetByTypeSubTypeCodeFormType(string typeCode, string subTypeCode, string formType, string status);

        IEnumerable<RigOapChecklistQuestion> GetRelatedQuestionSearch(int questionId, DateTime fromDate, DateTime toDate, string searchBy);

        bool UpdateRigChecklistAnswers(IEnumerable<RigOapChecklistQuestionAnswer> answers);
       
        RigOapChecklist AddAssessor(RigOapChecklistAssessor assessor);

        bool DeleteAssessor(Guid Id);

        RigChecklistValidationResult ValidateChecklist(Guid rigOapChecklistId);

        Guid AddProtocol(RigOapChecklist protocol);

        IEnumerable<RigOapChecklist> GetChecklistsForReview(int searchBy, int checklistId, DateTime fromDate, DateTime toDate);      

    }
}
