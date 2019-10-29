
using Ensco.Irma.Models.Domain.IRMA;
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Common.Commands.Lookup
{
    public class GetAllCriticalityRequest : IRequest<IEnumerable<Criticality>>
    { 
        public GetAllCriticalityRequest()
        { 
        }
    }
}