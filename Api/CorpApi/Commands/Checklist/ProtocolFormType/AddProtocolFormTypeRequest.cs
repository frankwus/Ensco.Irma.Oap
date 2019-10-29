using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolFormType
{
    public class AddProtocolFormTypeRequest : IRequest<OapProtocolFormType>
    {
        public AddProtocolFormTypeRequest(OapProtocolFormType protocolFormType)
        {
            ProtocolFormType = protocolFormType;
        }

        public OapProtocolFormType ProtocolFormType { get;  }
    }
}