using Ensco.Irma.Models.Domain.Oap.Checklist; 
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IOapChecklistQuestionTagMapRepository : IBaseIdRepository<OapChecklistQuestionTagMap, int>
    {
        IEnumerable<OapChecklistQuestion> GetQuestions(int oapTagId);
        IEnumerable<OapChecklistQuestionTag> GetTags(int oapChecklistQuestionId);
        IEnumerable<OapChecklistQuestionTagMap> GetByQuestionTag(int oapChecklistQuestionId,int oapTagId);

        IEnumerable<OapChecklistQuestionTagMap> GetAllTagsByQuestion(int oapChecklistQuestionId);


    }     
}
