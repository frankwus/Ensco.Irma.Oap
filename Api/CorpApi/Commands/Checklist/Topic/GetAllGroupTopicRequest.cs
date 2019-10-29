using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Topic
{
    public class GetAllGroupTopicRequest : IRequest<IEnumerable<OapChecklistTopic>>
    { 
        public GetAllGroupTopicRequest(int groupId)
        {
            GroupId = groupId;
        }

        public int GroupId { get; set; }
    }
}