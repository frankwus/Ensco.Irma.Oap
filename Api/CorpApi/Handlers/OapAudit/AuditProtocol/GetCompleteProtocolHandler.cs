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
    public class GetCompleteProtocolHandler : IRequestHandler<GetCompleteProtocolRequest, RigOapChecklist>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }
        
        public GetCompleteProtocolHandler(IRigOapChecklistService rigOapChecklistService)
        {
            RigOapChecklistService = rigOapChecklistService;                  
        }

        Task<RigOapChecklist> IRequestHandler<GetCompleteProtocolRequest, RigOapChecklist>.Handle(GetCompleteProtocolRequest request, CancellationToken cancellationToken)
        {
            var cl = RigOapChecklistService.GetCompleteChecklist(request.ProtocolId);

            return Task.FromResult(cl);
        }
    }
}