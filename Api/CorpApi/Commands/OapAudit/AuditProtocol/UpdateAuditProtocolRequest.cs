using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol
{
    public class UpdateAuditProtocolRequest : IRequest<RigOapChecklist>
    {
        public UpdateAuditProtocolRequest(RigOapChecklist protocol)
        {
            Protocol = protocol;
        }

        public RigOapChecklist Protocol { get;  }
    }
}