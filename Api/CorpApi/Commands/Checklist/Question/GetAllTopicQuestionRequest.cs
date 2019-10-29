using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Question
{
    public class GetAllTopicQuestionRequest : IRequest<IEnumerable<OapChecklistQuestion>>
    { 
        public GetAllTopicQuestionRequest(int topicId)
        {
            TopicId = topicId;
        }

        public int TopicId { get; set; }
    }
}