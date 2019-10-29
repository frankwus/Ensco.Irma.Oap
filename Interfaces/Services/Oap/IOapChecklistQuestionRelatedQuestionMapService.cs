using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IOapChecklistQuestionRelatedQuestionMapService : IEntityIdService<OapCheckListQuestionRelatedQuestionMap, int>
    {
        IEnumerable<OapChecklistQuestion> GetRelatedQuestions(int oapQuestionId);       
        
    }
}
