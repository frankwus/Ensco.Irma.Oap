using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Topic
{
    public class DeleteChecklistTopicRequest : IRequest<bool>
    { 
        public DeleteChecklistTopicRequest(int topicId)
        {
            TopicId = topicId;
        }

        public int TopicId { get; set; }
    }
}