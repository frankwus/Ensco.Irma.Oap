using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolFormType
{
    public class DeleteProtocolFormTypeRequest : IRequest<bool>
    { 
        public DeleteProtocolFormTypeRequest(int protocolFormTypeId)
        {
            ProtocolFormTypeId = protocolFormTypeId;
        }

        public int ProtocolFormTypeId {get; set;}
    }
}