using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist
{
    public class GetAllAuditProtocolsRequest : IRequest<IEnumerable<OapChecklist>>
    {
        public GetAllAuditProtocolsRequest()
        {
        }
       
    }
}