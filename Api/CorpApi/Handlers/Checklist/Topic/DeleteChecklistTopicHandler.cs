using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Topic;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Topic
{
    public class DeleteChecklistTopicHandler : IRequestHandler<DeleteChecklistTopicRequest, bool>
    {
        private IOapChecklistTopicService TopicService { get; set; }

        public DeleteChecklistTopicHandler(IOapChecklistTopicService topicService)
        {
            TopicService = topicService;
        }

        Task<bool> IRequestHandler<DeleteChecklistTopicRequest, bool>.Handle(DeleteChecklistTopicRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var topic = TopicService.Get(request.TopicId);
                 
                TopicService.Delete(topic);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}