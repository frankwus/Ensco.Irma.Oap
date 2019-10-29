using System.Collections.Generic;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapChecklistTopicService: HistoricalEntityIdService<IrmaOapDbContext, IOapChecklistTopicRepository, OapChecklistTopic,int>, IOapChecklistTopicService
    {
        public OapChecklistTopicService(IOapChecklistTopicRepository repository): base(repository)
        {
        }

        public IEnumerable<OapChecklistTopic> GetAllGroupTopics(int groupId)
        {
            return Repository.GetAllGroupTopics(groupId);
        }

        public IEnumerable<OapChecklistTopic> GetAllChecklistTopics(int checklistId)
        {
            return Repository.GetAllChecklistTopics(checklistId);
        }
    }
}
