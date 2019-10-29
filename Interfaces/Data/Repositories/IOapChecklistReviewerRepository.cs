using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IOapChecklistReviewerRepository : IHistoricalBaseIdRepository<OapChecklistReviewer, int>
    {
        IEnumerable<OapChecklistReviewer> GetActiveReviewerPositions(string rigId, int checklistId, DateTime today);
    }
}
