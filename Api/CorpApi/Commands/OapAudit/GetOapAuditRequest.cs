using Ensco.Irma.Models.Domain.Oap.Audit;
using MediatR;


namespace Ensco.Irma.Oap.Api.Corp.Commands.OapAudits
{
    public class GetOapAuditRequest: IRequest<OapAudit>
    {

        public GetOapAuditRequest(int Id)
        {
            aId = Id;
        }

        public int aId { get; set; }
    }
}