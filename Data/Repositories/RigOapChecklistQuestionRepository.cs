
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    using Ensco.Irma.Data.Context;
    using Ensco.Irma.Interfaces.Data.Repositories;
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;

    public class RigOapChecklistQuestionRepository : BaseIdRepository<IrmaOapDbContext, RigOapChecklistQuestion, Guid>, IRigOapChecklistQuestionRepository
    {
        public RigOapChecklistQuestionRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        protected override IQueryable<RigOapChecklistQuestion> AllItems => Items
                                                    .Include(q => q.OapChecklistQuestion)
                                                    .Include(q => q.Comments)
                                                    .Include(q => q.Answers)
                                                    ;

        public IEnumerable<RigOapChecklistQuestion> GetAllQuestions(int checklistQuestionId, DateTime fromDate, DateTime toDate)
        {
            return from it in AllItems.Include(c => c.OapChecklistQuestion)
                                      .Include(c => c.OapChecklistQuestion.OapChecklistTopic)
                                      .Include(c => c.RigOapChecklist.OapChecklist.OapType) //protocol
                                      .Include(c => c.Answers)
                                      .Include(c => c.RigOapChecklist.OapChecklist.Groups) //category   

                   where it.OapChecklistQuestionId == checklistQuestionId
                    && it.RigOapChecklist.ChecklistDateTime >= fromDate && it.RigOapChecklist.ChecklistDateTime <= toDate
                   select it;

        }

        public RigOapChecklistQuestion GetChecklistQuestionRigDetails(Guid rigChecklistQuestionId)
        {
            return (from q in Items.Include(q => q.OapChecklistQuestion).Include(q => q.RigOapChecklist)
                   select q).FirstOrDefault(q => q.Id == rigChecklistQuestionId);
        }
    }
}
