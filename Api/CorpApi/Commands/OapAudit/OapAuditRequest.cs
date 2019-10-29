using Ensco.Irma.Models.Domain.Oap.Audit;
using MediatR;


namespace Ensco.Irma.Oap.Api.Corp.Commands.OapAudits
{
    public class OapAuditRequest:IRequest<OapAudit>
    {

        public OapAuditRequest(OapAudit oapAudit)
        {
            Audit = oapAudit;
        }

        public OapAudit Audit{ get; }
    }
}