using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Topic
{
    public class GetChecklistTopicRequest : IRequest<OapChecklistTopic>
    { 
        public GetChecklistTopicRequest(int topicId)
        {
            TopicId = topicId;
        }


        public int TopicId { get; }
    }
}