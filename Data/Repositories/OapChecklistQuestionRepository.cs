using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    public class OapChecklistQuestionRepository : HistoricalBaseIdRepository<IrmaOapDbContext, OapChecklistQuestion, int>, IOapChecklistQuestionRepository
    {
        public OapChecklistQuestionRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        protected override IQueryable<OapChecklistQuestion> AllItems => Items.Include(q => q.ProtocolQuestionHeader).Include(q => q.OapChecklistTopic.OapChecklistGroup.OapChecklist.OapType);

        public IEnumerable<OapChecklistQuestion> GetAllSubGroupQuestions(int subGroupId)
        {
            return AllItems.Where(tp => tp.OapChecklistTopic.OapChecklistSubGroupId == subGroupId).ToList();
        }

        public IEnumerable<OapChecklistQuestion> GetAllChecklistQuestions(int checklistId)
        {
            return AllItems.Where(tp => tp.OapChecklistTopic.OapChecklistGroup.OapChecklistId == checklistId).ToList();
        }

        public IEnumerable<OapChecklistQuestion> GetAllTopicQuestions(int topicId)
        {
            return AllItems.Where(tp => tp.OapChecklistTopicId == topicId).ToList();
        }

        public IEnumerable<OapChecklistQuestion> GetAllProtocolQuestions(DateTime startDate, DateTime endDate)
        {
            return (from it in AllItems
                            where it.StartDateTime <= startDate && it.EndDateTime >= endDate && it.OapChecklistTopic.OapChecklistGroup.OapChecklist.OapType.IsProtocol
                            select it).ToList();
        }
    }
}
