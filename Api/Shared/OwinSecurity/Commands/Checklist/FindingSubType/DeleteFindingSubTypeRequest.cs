using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingSubType
{
    public class DeleteFindingSubTypeRequest : IRequest<bool>
    { 
        public DeleteFindingSubTypeRequest(int findingSubTypeId)
        {
            FindingSubTypeId = findingSubTypeId;
        }

        public int FindingSubTypeId { get; set;}
    }
}