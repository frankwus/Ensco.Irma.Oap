using Ensco.Irma.Models.Domain.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IRigOapChecklistQuestionFindingRepository : IBaseIdRepository<RigOapChecklistQuestionFinding, Guid>
    {
        IEnumerable<RigOapChecklistQuestionFinding> GetAll(Guid rigChecklistId);

        IEnumerable<RigOapChecklistQuestionFinding> GetAllPreviousChecklistQuestionFindings(string rigId, int oapChecklistId, int? questionId);

        IEnumerable<RigOapChecklistQuestionFinding> GetAllQuestionFindings(Guid rigChecklistQuestionId);

        IEnumerable<RigOapChecklistQuestionFinding> GetAllChecklistFindings(Guid rigChecklistId);

    }
}