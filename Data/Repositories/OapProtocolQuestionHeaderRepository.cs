using System.Data.Entity;
using System.Linq;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Data.Repositories
{
    public class OapProtocolQuestionHeaderRepository : HistoricalBaseIdRepository<IrmaOapDbContext, OapProtocolQuestionHeader, int>, IOapProtocolQuestionHeaderRepository
    {
        public OapProtocolQuestionHeaderRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        protected override IQueryable<OapProtocolQuestionHeader> AllItems => Items.Include(h => h.OapChecklistQuestion.OapChecklistTopic.OapChecklistGroup);

        public OapProtocolQuestionHeader GetBySection(int questionId, string section)
        {
            return Items.FirstOrDefault(h => h.OapChecklistQuestionId == questionId && h.Section.Equals(section));
        }
    }
}
