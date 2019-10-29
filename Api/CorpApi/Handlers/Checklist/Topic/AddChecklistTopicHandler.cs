using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Topic;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Topic
{
    public class AddChecklistTopicHandler : IRequestHandler<AddChecklistTopicRequest, OapChecklistTopic>
    {
        private IOapChecklistTopicService TopicService { get; set; }
    
        public AddChecklistTopicHandler(  IOapChecklistTopicService topicService)
        {

            TopicService = topicService; 
        }

        Task<OapChecklistTopic> IRequestHandler<AddChecklistTopicRequest, OapChecklistTopic>.Handle(AddChecklistTopicRequest request, CancellationToken cancellationToken)
        {

            int topicId = 0;
            using (var ts = new TransactionScope())
            {
                topicId = TopicService.Add(request.Topic); 
                
                ts.Complete();
            }

            return Task.FromResult(TopicService.Get(topicId));
        }

         
    }
}