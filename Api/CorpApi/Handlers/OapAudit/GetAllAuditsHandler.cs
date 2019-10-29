using System;
using System.Collections.Generic;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits;
using Ensco.Irma.Models.Domain.Oap.Audit;
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
    public class GetAllAuditsHandler: IRequestHandler<GetAllByStatusRequest, IEnumerable<OapAudit>>
    {

        private IOapAuditService Service { get; set; }

        public GetAllAuditsHandler(IOapAuditService aService)
        {
            Service = aService;
        }

        Task<IEnumerable<OapAudit>> IRequestHandler<GetAllByStatusRequest, IEnumerable<OapAudit>>.Handle(GetAllByStatusRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAllByStatus(request.Status);
            return Task.FromResult(cl);
        }
    }
}