using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Topic;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Topic
{
    using Ensco.Irma.Extensions;

    public class GetAllTopicHandler : IRequestHandler<GetAllTopicRequest, IEnumerable<OapChecklistTopic>>
    {
        private IOapChecklistTopicService Service { get; set; }

        public GetAllTopicHandler(IOapChecklistTopicService topicService)
        {
            Service = topicService;
        }

        Task<IEnumerable<OapChecklistTopic>> IRequestHandler<GetAllTopicRequest, IEnumerable<OapChecklistTopic>>.Handle(GetAllTopicRequest request, CancellationToken cancellationToken)
        {
            var list = Service.GetAll(request.StartDate, request.EndDate);             
            return Task.FromResult(list);
        }
    }
}