using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.OapAudits.AuditProtocol
{
    public class AddProtocolAssessorHandler : IRequestHandler<AddProtocolAssessorRequest, RigOapChecklist>
    {
        private readonly IRigOapChecklistService service;

        public AddProtocolAssessorHandler(IRigOapChecklistService service)
        {
            this.service = service;
        }
        public Task<RigOapChecklist> Handle(AddProtocolAssessorRequest request, CancellationToken cancellationToken)
        {
            request.Assessor.RigOapChecklistId = request.ProtocolId;
            var result = service.AddAssessor(request.Assessor);
            return Task.FromResult(result);
        }
    }
}