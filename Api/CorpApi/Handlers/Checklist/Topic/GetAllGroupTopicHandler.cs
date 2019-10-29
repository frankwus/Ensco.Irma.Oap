using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Topic;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Topic
{
    public class GetAllGroupTopicHandler : IRequestHandler<GetAllGroupTopicRequest, IEnumerable<OapChecklistTopic>>
    {
        private IOapChecklistTopicService TopicService { get; set; }

        public GetAllGroupTopicHandler(IOapChecklistTopicService topicService)
        {
            TopicService = topicService;
        }

        Task<IEnumerable<OapChecklistTopic>> IRequestHandler<GetAllGroupTopicRequest, IEnumerable<OapChecklistTopic>>.Handle(GetAllGroupTopicRequest request, CancellationToken cancellationToken)
        {
            var cl = TopicService.GetAllGroupTopics(request.GroupId);
            return Task.FromResult(cl);
        }
    }
}