using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Audit;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.OapAudits.AuditProtocol
{
    public class AddProtocolsHandler : IRequestHandler<AddProtocolsRequest, IEnumerable<RigOapChecklist>>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }
        private IOapAuditProtocolMapService AuditProtocolMapService { get; set; }

        public AddProtocolsHandler(IRigOapChecklistService rigOapChecklistService, IOapAuditProtocolMapService auditProtocolMapService)
        {
            RigOapChecklistService = rigOapChecklistService;
            AuditProtocolMapService = auditProtocolMapService;
        }


        Task<IEnumerable<RigOapChecklist>> IRequestHandler<AddProtocolsRequest, IEnumerable<RigOapChecklist>>.Handle(AddProtocolsRequest request, CancellationToken cancellationToken)
        {
            Guid protocolId = Guid.Empty;

            using (var ts = new TransactionScope())
            {
                foreach (var protocol in request.Protocols)
                {

                    protocolId = RigOapChecklistService.AddProtocol(protocol);

                    OapAuditProtocol modelAuditProtocol = new OapAuditProtocol();
                    modelAuditProtocol.Id = 0;
                    modelAuditProtocol.AuditId = request.AuditId;
                    modelAuditProtocol.RigOapCheckListId = protocolId;
                    var mapId = AuditProtocolMapService.Add(modelAuditProtocol);
                }
                ts.Complete();
            }

            var oapProtocols = AuditProtocolMapService.GetProtocolsByAuditId(request.AuditId);

            return Task.FromResult(oapProtocols);

        }
    }
}