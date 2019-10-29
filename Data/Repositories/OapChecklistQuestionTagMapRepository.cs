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
    public class OapChecklistQuestionTagMapRepository :  BaseIdRepository<IrmaOapDbContext, OapChecklistQuestionTagMap, int>, IOapChecklistQuestionTagMapRepository
    {
        public OapChecklistQuestionTagMapRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        protected override IQueryable<OapChecklistQuestionTagMap> AllItems => Items.Include(q => q.OapChecklistQuestionTag).Include(q=>q.OapChecklistQuestion);

        public IEnumerable<OapChecklistQuestion> GetQuestions(int oapTagId)
        {
            return AllItems.Where(q => q.OapChecklistQuestionTagId == oapTagId).Select(q => q.OapChecklistQuestion).ToList();
        }

        public IEnumerable<OapChecklistQuestionTag> GetTags(int oapChecklistQuestionId)
        {
            return AllItems.Where(q => q.OapChecklistQuestionId == oapChecklistQuestionId).Select(q => q.OapChecklistQuestionTag).ToList();
        }

        public IEnumerable<OapChecklistQuestionTagMap> GetByQuestionTag(int oapChecklistQuestionId, int oapTagId)
        {
            return AllItems.Where(q => q.OapChecklistQuestionId == oapChecklistQuestionId && q.OapChecklistQuestionTagId == oapTagId).ToList();
        }

        public IEnumerable<OapChecklistQuestionTagMap> GetAllTagsByQuestion(int oapChecklistQuestionId)
        {
            return AllItems.Where(q => q.OapChecklistQuestionId == oapChecklistQuestionId);
        }
    }
}
