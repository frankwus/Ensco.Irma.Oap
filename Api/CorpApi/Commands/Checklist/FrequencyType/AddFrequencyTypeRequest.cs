using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.FrequencyType
{
    public class AddFrequencyTypeRequest : IRequest<OapFrequencyType>
    {
        public AddFrequencyTypeRequest(OapFrequencyType frequencyType)
        {
            FrequencyType = frequencyType;
        }

        public OapFrequencyType FrequencyType { get;  }
    }
}