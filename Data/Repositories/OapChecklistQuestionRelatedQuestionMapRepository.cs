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
    public class OapChecklistQuestionRelatedQuestionMapRepository :  BaseIdRepository<IrmaOapDbContext, OapCheckListQuestionRelatedQuestionMap, int>, IOapChecklistQuestionRelatedQuestionMapRepository
    {
        public OapChecklistQuestionRelatedQuestionMapRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        protected override IQueryable<OapCheckListQuestionRelatedQuestionMap> AllItems => Items.Include(m => m.OapChecklistRelatedQuestion);

        public IEnumerable<OapChecklistQuestion> GetRelatedQuestions(int oapQuestionId)
        {
            return AllItems.Where( m => m.OapChecklistQuestionId == oapQuestionId).Select(c => c.OapChecklistRelatedQuestion).ToList();
        }
    }
}
