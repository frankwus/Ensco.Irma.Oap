using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.SubSystem
{
    public class GetAllSubSystemRequest : IRequest<IEnumerable<OapSubSystem>>
    { 
        public GetAllSubSystemRequest()
        {
           
        }         
    }
}