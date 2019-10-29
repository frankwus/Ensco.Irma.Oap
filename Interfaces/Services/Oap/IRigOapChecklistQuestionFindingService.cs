using Ensco.Irma.Models.Domain.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IRigOapChecklistQuestionFindingService : IEntityIdService<RigOapChecklistQuestionFinding, Guid>
    {
        IEnumerable<RigOapChecklistQuestionFinding> GetAll(Guid rigChecklistId);

        IEnumerable<RigOapChecklistQuestionFinding> GetAllQuestionPreviousFindings(Guid rigChecklistQuestionId);

        IEnumerable<RigOapChecklistQuestionFinding> GetAllQuestionFindings(Guid rigChecklistQuestionId);

        IEnumerable<RigOapChecklistQuestionFinding> GetAllChecklistFindings(Guid rigChecklistId);
    }
}
