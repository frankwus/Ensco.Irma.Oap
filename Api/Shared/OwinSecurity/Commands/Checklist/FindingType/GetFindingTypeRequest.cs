using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingType
{
    using Ensco.Irma.Models.Domain.Oap;

    public class GetFindingTypeRequest : IRequest<FindingType>
    { 
        public GetFindingTypeRequest(int findingTypeId)
        {
            FindingTypeId = findingTypeId;
        }

        public int FindingTypeId { get; set;}
    }
}