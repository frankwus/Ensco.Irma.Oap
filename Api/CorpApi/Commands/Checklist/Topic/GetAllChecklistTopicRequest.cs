using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Topic
{
    public class GetAllChecklistTopicRequest : IRequest<IEnumerable<OapChecklistTopic>>
    { 
        public GetAllChecklistTopicRequest(int checklistId)
        {
            ChecklistId = checklistId;
        }

        public int ChecklistId { get; set; }
    }
}