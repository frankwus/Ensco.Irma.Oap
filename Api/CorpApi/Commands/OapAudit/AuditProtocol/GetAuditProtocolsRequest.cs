using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol
{
    public class GetAuditProtocolsRequest : IRequest<IEnumerable<RigOapChecklist>>
    {
        public GetAuditProtocolsRequest(int auditId)
        {
            AuditId = auditId;
        }

        public int AuditId { get; }
    }
}