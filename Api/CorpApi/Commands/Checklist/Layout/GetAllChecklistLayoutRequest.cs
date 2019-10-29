using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Layout
{
    public class GetAllChecklistLayoutRequest : IRequest<IEnumerable<OapChecklistLayout>>
    { 
        public GetAllChecklistLayoutRequest()
        { 
        }
    }
}