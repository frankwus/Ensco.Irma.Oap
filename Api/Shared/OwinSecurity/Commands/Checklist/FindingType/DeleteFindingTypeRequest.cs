using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingType
{
    public class DeleteFindingTypeRequest : IRequest<bool>
    { 
        public DeleteFindingTypeRequest(int findingTypeId)
        {
            FindingTypeId = findingTypeId;
        }

        public int FindingTypeId { get; set;}
    }
}