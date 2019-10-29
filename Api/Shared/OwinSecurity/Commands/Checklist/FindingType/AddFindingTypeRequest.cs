using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingType
{
    using Ensco.Irma.Models.Domain.Oap; 

    public class AddFindingTypeRequest : IRequest<FindingType>
    {
        public AddFindingTypeRequest(FindingType findingType)
        {
            FindingType = findingType;
        }

        public FindingType FindingType { get;  }
    }
}