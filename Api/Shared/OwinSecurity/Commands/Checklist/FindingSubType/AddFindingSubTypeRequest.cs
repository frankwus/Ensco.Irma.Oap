using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingSubType
{
    using Ensco.Irma.Models.Domain.Oap; 

    public class AddFindingSubTypeRequest : IRequest<FindingSubType>
    {
        public AddFindingSubTypeRequest(FindingSubType findingSubType)
        {
            FindingSubType = findingSubType;
        }

        public FindingSubType FindingSubType { get;  }
    }
}