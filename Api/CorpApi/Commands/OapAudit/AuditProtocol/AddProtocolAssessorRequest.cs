using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol  
{
    public class AddProtocolAssessorRequest : IRequest<RigOapChecklist>
    {
        public AddProtocolAssessorRequest(Guid protocolId, RigOapChecklistAssessor assessor)
        {
            ProtocolId = protocolId;
            Assessor = assessor;
        }

        public Guid ProtocolId { get; }
        public RigOapChecklistAssessor Assessor { get; }
    }
}