using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.OapAudits
{
    public class ValidateOapAuditHandler : IRequestHandler<ValidateOapAuditRequest, RigChecklistValidationResult>
    {
        private readonly IOapAuditService service;

        public ValidateOapAuditHandler(IOapAuditService service)
        {
            this.service = service;
        }

        public Task<RigChecklistValidationResult> Handle(ValidateOapAuditRequest request, CancellationToken cancellationToken)
        {
            var result = service.ValidateAuditProtocols(request.AuditId);
            return Task.FromResult(result);
        }
    }
}