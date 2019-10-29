using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
       
namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.Frequency
{
    public class AddFrequencyRequest : IRequest<OapFrequency>
    {
        public AddFrequencyRequest(OapFrequency frequency)
        {
            Frequency = frequency;
        }

        public OapFrequency Frequency { get;  }
    }
}