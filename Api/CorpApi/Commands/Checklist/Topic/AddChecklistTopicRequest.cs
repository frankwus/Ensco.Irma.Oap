using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Topic
{
    public class AddChecklistTopicRequest : IRequest<OapChecklistTopic>
    {
        public AddChecklistTopicRequest(OapChecklistTopic topic)
        {
            Topic = topic;
        }

        public OapChecklistTopic Topic { get;  }
    }
}