using System;
using System.Collections.Generic;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapChecklistQuestionTagService : EntityIdService<IrmaOapDbContext, IOapChecklistQuestionTagRepository, OapChecklistQuestionTag, int>, IOapChecklistQuestionTagService
    {
        public OapChecklistQuestionTagService(IOapChecklistQuestionTagRepository repository) : base(repository)
        {

        }

        public OapChecklistQuestionTag GetByTag(string tag)
        {
            return Repository.GetByTag(tag);
        }
    }
}
