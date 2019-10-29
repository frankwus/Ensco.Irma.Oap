using MediatR;

    using System;
namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingSubType
{
    using Ensco.Irma.Models.Domain.Oap;

    public class UpdateFindingSubTypeRequest : IRequest<bool>
    {
        public UpdateFindingSubTypeRequest(FindingSubType findingSubType)
        {
            FindingSubType = findingSubType;
        }

        public FindingSubType FindingSubType { get;  }
    }
}