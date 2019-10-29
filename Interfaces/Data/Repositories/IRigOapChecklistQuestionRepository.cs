using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IRigOapChecklistQuestionRepository : IBaseIdRepository<RigOapChecklistQuestion, Guid>
    {
        IEnumerable<RigOapChecklistQuestion> GetAllQuestions(int checklistQuestionId, DateTime fromDate, DateTime toDate);

        RigOapChecklistQuestion GetChecklistQuestionRigDetails(Guid rigQuestionId);
    }
}
