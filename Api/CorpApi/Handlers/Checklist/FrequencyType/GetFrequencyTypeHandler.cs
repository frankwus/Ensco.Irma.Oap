using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.FrequencyType;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.FrequencyType
{
    public class GetFrequencyTypeHandler : IRequestHandler<GetFrequencyTypeRequest, OapFrequencyType>
    {
        private IOapFrequencyTypeService Service { get; set; }

        public GetFrequencyTypeHandler(IOapFrequencyTypeService frequencyTypeService)
        {
            Service = frequencyTypeService;
        }

        Task<OapFrequencyType> IRequestHandler<GetFrequencyTypeRequest, OapFrequencyType>.Handle(GetFrequencyTypeRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.Get(request.FrequencyTypeId);
            return Task.FromResult(cl);
        }
    }
}