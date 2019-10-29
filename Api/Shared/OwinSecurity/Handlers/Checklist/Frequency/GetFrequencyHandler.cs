using Ensco.Irma.Interfaces.Services;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Frequency;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Frequency
{
    public class GetFrequencyHandler : IRequestHandler<GetFrequencyRequest, OapFrequency>
    {
        private IOapFrequencyService Service { get; set; }

        public GetFrequencyHandler(IOapFrequencyService frequencyService)
        {
            Service = frequencyService;
        }

        Task<OapFrequency> IRequestHandler<GetFrequencyRequest, OapFrequency>.Handle(GetFrequencyRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.Get(request.FrequencyId);
            return Task.FromResult(cl);
        }
    }
}