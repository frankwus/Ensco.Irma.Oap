using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Topic;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Topic
{
    public class GetAllChecklistTopicHandler : IRequestHandler<GetAllChecklistTopicRequest, IEnumerable<OapChecklistTopic>>
    {
        private IOapChecklistTopicService TopicService { get; set; }

        public GetAllChecklistTopicHandler(IOapChecklistTopicService topicService)
        {
            TopicService = topicService;
        }

        Task<IEnumerable<OapChecklistTopic>> IRequestHandler<GetAllChecklistTopicRequest, IEnumerable<OapChecklistTopic>>.Handle(GetAllChecklistTopicRequest request, CancellationToken cancellationToken)
        {
            var cl = TopicService.GetAllChecklistTopics(request.ChecklistId);
            return Task.FromResult(cl);
        }
    }
}