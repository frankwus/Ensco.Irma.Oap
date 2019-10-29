using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class GetRelatedQuestionSearchChecklistRequest : IRequest<IEnumerable<RigOapChecklistQuestion>>
    {       
        public GetRelatedQuestionSearchChecklistRequest(int questionId, DateTime fromDate, DateTime toDate , string searchBy)
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