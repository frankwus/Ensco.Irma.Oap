using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Topic;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Topic
{
    public class GetChecklistTopicHandler : IRequestHandler<GetChecklistTopicRequest, OapChecklistTopic>
    {
        private IOapChecklistTopicService TopicService { get; set; }

        public GetChecklistTopicHandler(IOapChecklistTopicService topicService)
        {
            TopicService = topicService;
        }

        Task<OapChecklistTopic> IRequestHandler<GetChecklistTopicRequest, OapChecklistTopic>.Handle(GetChecklistTopicRequest request, CancellationToken cancellationToken)
        {
            var cl = TopicService.Get(request.TopicId);
            return Task.FromResult(cl);
        }
    }
}