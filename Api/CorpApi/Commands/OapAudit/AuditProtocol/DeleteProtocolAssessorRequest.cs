using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol  
{
    public class DeleteProtocolAssessorRequest : IRequest<bool>
    {
        public DeleteProtocolAssessorRequest(Guid assessorId)
        {
            this.AssessorId = assessorId;
        }
        public Guid AssessorId { get; }
    }
   
}    