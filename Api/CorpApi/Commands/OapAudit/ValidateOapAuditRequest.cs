using Ensco.Irma.Models.Domain.Oap;
using MediatR;
using System;


namespace Ensco.Irma.Oap.Api.Corp.Commands.OapAudits
{
    public class ValidateOapAuditRequest: IRequest<RigChecklistValidationResult>
    {
    public ValidateOapAuditRequest(int auditId)
    {
        AuditId = auditId;
    }

    public int AuditId { get; }
}

}
