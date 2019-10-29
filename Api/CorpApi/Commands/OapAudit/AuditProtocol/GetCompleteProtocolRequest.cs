using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol
{
    public class GetCompleteProtocolRequest : IRequest<RigOapChecklist>
    {
        public GetCompleteProtocolRequest(Guid protocolId)
        {
            ProtocolId = protocolId;
        }

        public Guid ProtocolId { get; set; }
    }
}