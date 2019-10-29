using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Topic;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Category
{
    public class UpdateChecklistTopicHandler : IRequestHandler<UpdateChecklistTopicRequest, bool>
    {
        private IOapChecklistTopicService TopicService { get; set; }
         

        private IMapper Mapper { get; set;  }

        public UpdateChecklistTopicHandler(IOapChecklistTopicService topicService, IMapper mapper)
        {
            TopicService = topicService;
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateChecklistTopicRequest, bool>.Handle(UpdateChecklistTopicRequest request, CancellationToken cancellationToken)
        {
            var existingTopic = TopicService.Get(request.Topic.Id);

            if (existingTopic == null)
            {
                throw new ApplicationException($"UpdateChecklistTopicHandler: Topic with Id {request.Topic.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.Topic, existingTopic);

            using (var ts = new TransactionScope())
            {
                var updatedTopic = TopicService.Update(existingTopic);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}