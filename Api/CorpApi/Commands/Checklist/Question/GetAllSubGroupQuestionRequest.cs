using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Question
{
    public class GetAllSubGroupQuestionRequest : IRequest<IEnumerable<OapChecklistQuestion>>
    { 
        public GetAllSubGroupQuestionRequest(int subGroupId)
        {
            SubGroupId = subGroupId;
        }

        public int SubGroupId { get; set; }
    }
}