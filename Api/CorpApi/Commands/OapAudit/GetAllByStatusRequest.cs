using Ensco.Irma.Models.Domain.Oap.Audit;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.OapAudits
{
    public class GetAllByStatusRequest:IRequest<IEnumerable<OapAudit>>
    {

        public GetAllByStatusRequest(string status)
        {
            Status = status;
        }

        public string Status{ get; }
    }
}