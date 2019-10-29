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
    public class OapChecklistQuestionTagRepository : BaseIdRepository<IrmaOapDbContext, OapChecklistQuestionTag, int>, IOapChecklistQuestionTagRepository
    {
        public OapChecklistQuestionTagRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        public OapChecklistQuestionTag GetByTag(string tag)
        {
            return Items.Where(t => t.Tag.Equals(tag))?.FirstOrDefault();
        }
    }
}
