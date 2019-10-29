using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.Frequency
{
    public class GetFrequencyRequest : IRequest<OapFrequency>
    { 
        public GetFrequencyRequest(int frequencyId)
        {
            FrequencyId = frequencyId;
        }

        public int FrequencyId {get; set;}
    }
}