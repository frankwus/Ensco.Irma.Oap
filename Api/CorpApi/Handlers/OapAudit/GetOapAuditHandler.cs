using Ensco.Irma.Models.Domain.Oap.Audit;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits;
using Ensco.Irma.Interfaces.Services.Oap;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.OapAudits
{
    public class GetOapAuditHandler: IRequestHandler<GetOapAuditRequest, OapAudit>
    {

        private IOapAuditService Service { get; set; }

        public GetOapAuditHandler(IOapAuditService auditService)
        {
            Service = auditService;
        }

        Task<OapAudit> IRequestHandler<GetOapAuditRequest, OapAudit>.Handle(GetOapAuditRequest request, CancellationToken cancellationToken)
        {
            //var cl = Service.Get(request.aId);
            var cl = Service.GetAudit(request.aId);
            return Task.FromResult(cl);
        }

        
    }
}