
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingSubType
{
    using  Ensco.Irma.Models.Domain.Oap; 

    public class GetAllFindingSubTypeRequest : IRequest<IEnumerable<FindingSubType>>
    { 
        public GetAllFindingSubTypeRequest()
        { 
        }
    }
}