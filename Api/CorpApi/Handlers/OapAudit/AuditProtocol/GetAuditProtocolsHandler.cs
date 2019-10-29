using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.OapAudits.AuditProtocol
{
    public class GetAuditProtocolsHandler : IRequestHandler<GetAuditProtocolsRequest, IEnumerable<RigOapChecklist>>
    {         
        private IOapAuditProtocolMapService OapAuditProtocolMapService { get; set; }

        public GetAuditProtocolsHandler(IOapAuditProtocolMapService oapAuditProtocolMapService)
        {
            OapAuditProtocolMapService = oapAuditProtocolMapService;
        }

        public Task<IEnumerable<RigOapChecklist>> Handle(GetAuditProtocolsRequest request, CancellationToken cancellationToken)
        {           
            var cl = OapAuditProtocolMapService.GetProtocolsByAuditId(request.AuditId);
            return Task.FromResult(cl);
        }

    }
}