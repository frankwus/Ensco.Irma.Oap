using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IOapChecklistTopicRepository:IHistoricalBaseIdRepository<OapChecklistTopic, int>
    {
        IEnumerable<OapChecklistTopic> GetAllGroupTopics(int groupId);

        IEnumerable<OapChecklistTopic> GetAllChecklistTopics(int checklistId);
    }
}
