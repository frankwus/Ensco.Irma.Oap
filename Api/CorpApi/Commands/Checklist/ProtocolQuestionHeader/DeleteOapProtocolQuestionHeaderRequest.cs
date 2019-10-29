using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolQuestionHeader
{
    public class DeleteOapProtocolQuestionHeaderRequest : IRequest<bool>
    { 
        public DeleteOapProtocolQuestionHeaderRequest(int questionHeaderId)
        {
            QuestionHeaderId = questionHeaderId;
        }

        public int QuestionHeaderId { get; set;}
    }
}