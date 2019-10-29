using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.Frequency
{
    public class DeleteFrequencyRequest : IRequest<bool>
    { 
        public DeleteFrequencyRequest(int frequencyId)
        {
            FrequencyId = frequencyId;
        }

        public int FrequencyId {get; set;}
    }
}