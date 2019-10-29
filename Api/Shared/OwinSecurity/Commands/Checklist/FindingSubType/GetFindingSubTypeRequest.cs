using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingSubType
{
    using Ensco.Irma.Models.Domain.Oap;

    public class GetFindingSubTypeRequest : IRequest<FindingSubType>
    { 
        public GetFindingSubTypeRequest(int findingSubTypeId)
        {
            FindingSubTypeId = findingSubTypeId;
        }

        public int FindingSubTypeId { get; set;}
    }
}