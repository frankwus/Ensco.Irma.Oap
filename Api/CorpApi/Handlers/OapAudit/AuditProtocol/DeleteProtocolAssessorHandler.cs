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
    public class DeleteProtocolAssessorHandler : IRequestHandler<DeleteProtocolAssessorRequest, bool>
    {
        private readonly IRigOapChecklistService service;

        public DeleteProtocolAssessorHandler(IRigOapChecklistService service)
        {
            this.service = service;
        }
        public Task<bool> Handle(DeleteProtocolAssessorRequest request, CancellationToken cancellationToken)
        {
            var result = service.DeleteAssessor(request.AssessorId);
            return Task.FromResult(result);
        }        
    }
}