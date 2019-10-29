using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol
{
    public class GetRelatedQuestionSearchProtocolRequest : IRequest<IEnumerable<RigOapChecklistQuestion>>
    {       
        public GetRelatedQuestionSearchProtocolRequest(int questionId, DateTime fromDate, DateTime toDate , string searchBy)
        {
            QuestionId = questionId;
            FromDate = fromDate;
            ToDate = toDate;
            SearchBy = searchBy;
        }

        public int QuestionId { get; }
        public DateTime FromDate { get; }
        public DateTime ToDate { get; }
        public string SearchBy { get; }
    }
}