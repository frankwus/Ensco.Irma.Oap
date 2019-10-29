using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolFormType
{
    public class GetProtocolFormTypeRequest : IRequest<OapProtocolFormType>
    { 
        public GetProtocolFormTypeRequest(int protocolFormTypeId)
        {
            ProtocolFormTypeId = protocolFormTypeId;
        }

        public int ProtocolFormTypeId {get; set;}
    }
}