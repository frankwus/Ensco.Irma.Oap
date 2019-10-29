using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.FrequencyType
{
    public class DeleteFrequencyTypeRequest : IRequest<bool>
    { 
        public DeleteFrequencyTypeRequest(int frequencyTypeId)
        {
            FrequencyTypeId = frequencyTypeId;
        }

        public int FrequencyTypeId {get; set;}
    }
}