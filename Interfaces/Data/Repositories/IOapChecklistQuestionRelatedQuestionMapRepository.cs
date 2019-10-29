using System;
using Ensco.Irma.Models.Domain.Oap.Checklist; 
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IOapChecklistQuestionRelatedQuestionMapRepository : IBaseIdRepository<OapCheckListQuestionRelatedQuestionMap, int>
    {
        IEnumerable<OapChecklistQuestion> GetRelatedQuestions(int oapQuestionId);
       
    }
}
