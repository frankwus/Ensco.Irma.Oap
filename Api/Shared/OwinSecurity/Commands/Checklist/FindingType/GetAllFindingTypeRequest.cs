
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingType
{
    using  Ensco.Irma.Models.Domain.Oap; 

    public class GetAllFindingTypeRequest : IRequest<IEnumerable<FindingType>>
    { 
        public GetAllFindingTypeRequest()
        { 
        }
    }
}