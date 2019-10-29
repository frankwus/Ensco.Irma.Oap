using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolFormType
{
    public class UpdateProtocolFormTypeRequest : IRequest<bool>
    {
        public UpdateProtocolFormTypeRequest(OapProtocolFormType protocolFormType)
        {
            ProtocolFormType = protocolFormType;
        }

        public OapProtocolFormType ProtocolFormType { get;  }
    }
}