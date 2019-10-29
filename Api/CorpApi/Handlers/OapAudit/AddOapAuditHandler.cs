using System;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits;
using Ensco.Irma.Models.Domain.Oap.Audit;
using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.OapAudits
{
    public class AddOapAuditHandler: IRequestHandler<OapAuditRequest, OapAudit>
    {

        private IOapAuditService AuditService { get; set; }

        public AddOapAuditHandler(IOapAuditService auditService)
        {
            AuditService = auditService;
        }

        Task<OapAudit> IRequestHandler<OapAuditRequest, OapAudit>.Handle(OapAuditRequest request, CancellationToken cancellationToken)
        {
            var existingAudit = AuditService.Get(request.Audit.Id);
            if (existingAudit != null)
            {
                return Task.FromResult(existingAudit);
            }

            int newAuditId = 0;
            using (var ts = new TransactionScope())
            {
                if (request.Audit.StartDateTime.IsDefaultMin() || request.Audit.StartDateTime.IsDefaultMax())
                {
                    request.Audit.StartDateTime = DateTime.Now;
                }

                if (request.Audit.EndDateTime.IsDefaultMin())
                {
                    request.Audit.EndDateTime = DateTime.MaxValue;
                }

                newAuditId = AuditService.Add(request.Audit);

                ts.Complete();
            }
            return Task.FromResult(AuditService.Get(newAuditId));
        }
    }
}