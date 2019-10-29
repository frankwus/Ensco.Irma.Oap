using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingType
{
    using Ensco.Irma.Models.Domain.Oap;

    public class UpdateFindingTypeRequest : IRequest<bool>
    {
        public UpdateFindingTypeRequest(FindingType findingType)
        {
            FindingType = findingType;
        }

        public FindingType FindingType { get;  }
    }
}