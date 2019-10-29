using MediatR;
using System.Collections.Generic;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol
{
    public class AddProtocolsRequest : IRequest<IEnumerable<RigOapChecklist>>
    {
        public AddProtocolsRequest(int auditId , IEnumerable<RigOapChecklist> protocols)
        {
            AuditId = auditId;
            Protocols = protocols;           
        }
        public int AuditId { get; }
        public IEnumerable<RigOapChecklist> Protocols { get;  }
    
    }
}