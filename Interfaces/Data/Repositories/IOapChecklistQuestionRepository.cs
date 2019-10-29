using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IOapChecklistQuestionRepository : IHistoricalBaseIdRepository<OapChecklistQuestion, int>
    {
        IEnumerable<OapChecklistQuestion> GetAllSubGroupQuestions(int subGroupId);

        IEnumerable<OapChecklistQuestion> GetAllChecklistQuestions(int checklistId);

        IEnumerable<OapChecklistQuestion> GetAllTopicQuestions(int topicId);

        IEnumerable<OapChecklistQuestion> GetAllProtocolQuestions(DateTime startDate, DateTime endDate);
    }
}
