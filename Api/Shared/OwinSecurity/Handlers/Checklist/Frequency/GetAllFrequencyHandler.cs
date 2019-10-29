using Ensco.Irma.Interfaces.Services;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Frequency;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.Frequency
{
    public class GetAllFrequencyHandler : IRequestHandler<GetAllFrequencyRequest, IEnumerable<OapFrequency>>
    {
        private IOapFrequencyService Service { get; set; }

        public GetAllFrequencyHandler(IOapFrequencyService frequencyService)
        {
            Service = frequencyService;
        }

        Task<IEnumerable<OapFrequency>> IRequestHandler<GetAllFrequencyRequest, IEnumerable<OapFrequency>>.Handle(GetAllFrequencyRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAll(request.StartDate, request.EndDate);
            return Task.FromResult(cl);
        }
    }
}