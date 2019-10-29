using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolQuestionHeader
{
    public class AddOapProtocolQuestionHeaderRequest : IRequest<OapProtocolQuestionHeader>
    {
        public AddOapProtocolQuestionHeaderRequest(OapProtocolQuestionHeader header)
        {
            Header = header;
        }

        public OapProtocolQuestionHeader Header { get;  }
    }
}