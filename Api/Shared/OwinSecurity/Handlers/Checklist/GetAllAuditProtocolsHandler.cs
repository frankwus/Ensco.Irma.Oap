using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist
{
    public class GetAllAuditProtocolsHandler : IRequestHandler<GetAllAuditProtocolsRequest, IEnumerable<OapChecklist>>
    {
        private IOapChecklistService Service { get; set; }

        public GetAllAuditProtocolsHandler(IOapChecklistService checklistService)
        {
            Service = checklistService;
        }

        Task<IEnumerable<OapChecklist>> IRequestHandler<GetAllAuditProtocolsRequest, IEnumerable<OapChecklist>>.Handle(GetAllAuditProtocolsRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAllAuditProtocols();
            return Task.FromResult(cl);
        }
    }
}