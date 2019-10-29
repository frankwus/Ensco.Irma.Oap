
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Common.Lookup
{
    using Ensco.Irma.Interfaces.Services.Security;
    using Ensco.Irma.Models.Domain.IRMA;
    using Ensco.Irma.Oap.Api.Common.Commands.Lookup;

    public class GetAllCriticalityHandler : IRequestHandler<GetAllCriticalityRequest, IEnumerable<Criticality>>
    {
        private ICriticalityService Service { get; set; }

        public GetAllCriticalityHandler(ICriticalityService criticalityService)
        {
            Service = criticalityService;
        }

        Task<IEnumerable<Criticality>> IRequestHandler<GetAllCriticalityRequest, IEnumerable<Irma.Models.Domain.IRMA.Criticality>>.Handle(GetAllCriticalityRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAll();
            return Task.FromResult(cl);
        }
    }
}