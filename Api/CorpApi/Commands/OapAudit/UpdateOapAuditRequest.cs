using Ensco.Irma.Models.Domain.Oap.Audit;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.OapAudits
{
    public class UpdateOapAuditRequest: IRequest<bool>
    {

        public UpdateOapAuditRequest(OapAudit oapAudit)
        {
            Audit = oapAudit;
        }

        public OapAudit Audit { get; }
    }

    
}