using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol
{
    public class AddAuditProtocolRequest : IRequest<RigOapChecklist>
    {
        public AddAuditProtocolRequest(int auditId , RigOapChecklist protocol)
        {
            AuditId = auditId;
            Protocol = protocol;           
        }
        public int AuditId { get; }
        public RigOapChecklist Protocol { get;  }
    
    }
}