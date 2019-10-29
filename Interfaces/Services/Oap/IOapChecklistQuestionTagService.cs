using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IOapChecklistQuestionTagService :  IEntityIdService<OapChecklistQuestionTag, int>
    {
        OapChecklistQuestionTag GetByTag(string tag);
    }
}
