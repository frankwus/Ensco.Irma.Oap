using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolQuestionHeader
{
    public class GetOapProtocolQuestionHeaderRequest : IRequest<OapProtocolQuestionHeader>
    { 
        public GetOapProtocolQuestionHeaderRequest(int questionHeaderId)
        {
            QuestionHeaderId = questionHeaderId;
        }

        public int QuestionHeaderId {get; set;}
    }
}