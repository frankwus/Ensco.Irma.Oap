using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    public class OapChecklistTopicRepository : HistoricalBaseIdRepository<IrmaOapDbContext, OapChecklistTopic, int>, IOapChecklistTopicRepository 
    {
        public OapChecklistTopicRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        protected override IQueryable<OapChecklistTopic> AllItems => Items.Include(c => c.Questions);

        public IEnumerable<OapChecklistTopic> GetAllGroupTopics(int groupId)
        {
            return AllItems.Where(tp => tp.OapChecklistGroupId == groupId).ToList();
        }

        public IEnumerable<OapChecklistTopic> GetAllChecklistTopics(int checklistId)
        {
            return AllItems.Where(tp => tp.OapChecklistGroup.OapChecklistId == checklistId).ToList();
        }
    }
}
