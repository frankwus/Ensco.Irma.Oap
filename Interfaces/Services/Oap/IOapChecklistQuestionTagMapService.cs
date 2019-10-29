using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IOapChecklistQuestionTagMapService : IEntityIdService<OapChecklistQuestionTagMap, int>
    {
        IEnumerable<OapChecklistQuestion> GetQuestions(int oapTagId);
        IEnumerable<OapChecklistQuestionTag> GetTags(int oapChecklistQuestionId);
        OapChecklistQuestionTagMap GetByQuestionTag(int oapChecklistQuestionId, int oapTagId);
        IEnumerable<OapChecklistQuestionTagMap> GetAllTagsByQuestion(int oapChecklistQuestionId); 
    }
}
