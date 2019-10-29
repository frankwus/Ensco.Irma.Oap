using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Audit;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.OapAudits.AuditProtocol
{
    public class AddAuditProtocolHandler : IRequestHandler<AddAuditProtocolRequest, RigOapChecklist>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }
        private IOapAuditProtocolMapService AuditProtocolMapService { get; set; }    

        public AddAuditProtocolHandler(IRigOapChecklistService rigOapChecklistService, IOapAuditProtocolMapService auditProtocolMapService)
        {
            RigOapChecklistService = rigOapChecklistService;
            AuditProtocolMapService = auditProtocolMapService;          
        }


        Task<RigOapChecklist> IRequestHandler<AddAuditProtocolRequest, RigOapChecklist>.Handle(AddAuditProtocolRequest request, CancellationToken cancellationToken)
        {
            Guid protocolId = Guid.Empty;


            using (var ts = new TransactionScope())
            {
                protocolId = RigOapChecklistService.AddProtocol(request.Protocol);

                OapAuditProtocol modelAuditProtocol = new OapAuditProtocol();
                modelAuditProtocol.Id = 0;
                modelAuditProtocol.AuditId = request.AuditId;
                modelAuditProtocol.RigOapCheckListId = protocolId;
                var mapId = AuditProtocolMapService.Add(modelAuditProtocol);

                ts.Complete();
            }

            var oapProtocol = RigOapChecklistService.GetCompleteChecklist(protocolId);
            
            return Task.FromResult(oapProtocol);
        }
    }
}