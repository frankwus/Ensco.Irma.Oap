using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol
{
    public class GetChecklistsForReviewRequest : IRequest<IEnumerable<RigOapChecklist>>
    {
        public GetChecklistsForReviewRequest(int searchBy, int checklistId, DateTime fromDate, DateTime toDate)
        {
            SearchBy = searchBy;
            ChecklistId = checklistId;
            FromDate = fromDate;
            ToDate = toDate;
        }
        public int SearchBy { get; }
        public int ChecklistId { get; }
        public DateTime FromDate { get; }
        public DateTime ToDate { get; }

    }
}