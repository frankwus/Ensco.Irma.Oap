using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.FrequencyType
{
    public class GetFrequencyTypeRequest : IRequest<OapFrequencyType>
    { 
        public GetFrequencyTypeRequest(int frequencyTypeId)
        {
            FrequencyTypeId = frequencyTypeId;
        }

        public int FrequencyTypeId {get; set;}
    }
}