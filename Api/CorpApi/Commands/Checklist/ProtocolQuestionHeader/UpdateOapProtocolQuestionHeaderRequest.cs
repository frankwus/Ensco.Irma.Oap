using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolQuestionHeader
{
    public class UpdateOapProtocolQuestionHeaderRequest : IRequest<bool>
    {
        public UpdateOapProtocolQuestionHeaderRequest(OapProtocolQuestionHeader questionHeader)
        {
            QuestionHeader = questionHeader;
        }

        public OapProtocolQuestionHeader QuestionHeader { get;  }
    }
}