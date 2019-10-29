using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.Frequency
{
    public class UpdateFrequencyRequest : IRequest<bool>
    {
        public UpdateFrequencyRequest(OapFrequency frequency)
        {
            Frequency = frequency;
        }

        public OapFrequency Frequency { get;  }
    }
}