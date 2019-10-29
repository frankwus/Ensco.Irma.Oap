using System;
using System.Collections.Generic;
using System.Linq;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapChecklistQuestionRelatedQuestionMapService : EntityIdService<IrmaOapDbContext, IOapChecklistQuestionRelatedQuestionMapRepository, OapCheckListQuestionRelatedQuestionMap, int>, IOapChecklistQuestionRelatedQuestionMapService
    {
        public OapChecklistQuestionRelatedQuestionMapService(IOapChecklistQuestionRelatedQuestionMapRepository repository) : base(repository)
        {

        }

        public IEnumerable<OapChecklistQuestion> GetRelatedQuestions(int oapQuestionId)
        {
            return Repository.GetRelatedQuestions(oapQuestionId);
        }
    }
}
