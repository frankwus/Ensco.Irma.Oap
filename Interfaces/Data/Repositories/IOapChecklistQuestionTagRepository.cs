using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IOapChecklistQuestionTagRepository : IBaseIdRepository<OapChecklistQuestionTag, int>
    {
        OapChecklistQuestionTag GetByTag(string tag);
    }
}
