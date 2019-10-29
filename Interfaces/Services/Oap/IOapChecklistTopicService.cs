using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IOapChecklistTopicService : IHistoricalEntityIdService<OapChecklistTopic, int>
    {
        IEnumerable<OapChecklistTopic> GetAllGroupTopics(int categoryId);

        IEnumerable<OapChecklistTopic> GetAllChecklistTopics(int categoryId);
    }
}
