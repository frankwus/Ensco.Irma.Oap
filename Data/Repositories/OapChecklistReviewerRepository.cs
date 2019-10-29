using System;
using System.Collections.Generic;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    public class OapChecklistReviewerRepository : HistoricalBaseIdRepository<IrmaOapDbContext, OapChecklistReviewer, int>, IOapChecklistReviewerRepository
    {
        public OapChecklistReviewerRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext) context, log)
        {

        }

        public IEnumerable<OapChecklistReviewer> GetActiveReviewerPositions(string rigId, int checklistId, DateTime today)
        {
            return (from r in AllItems
                    where r.RigId == rigId && r.OapChecklistId == checklistId && r.StartDateTime <= today && today <= r.EndDateTime
                    select r).ToList();
        }
    }
}
