using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.People
{
    using Ensco.Irma.Interfaces.Services.Security;
    using Ensco.Irma.Models.Domain.IRMA;
    using Ensco.Irma.Models.Domain.Security;
    using Ensco.Irma.Oap.Api.Common.Commands.People;

    public class GetPobPersonnelHandler : IRequestHandler<GetPobPersonnelRequest, int?>
    {
        private IPeopleService Service { get; set; }

        public GetPobPersonnelHandler(IPeopleService peopleService)
        {
            Service = peopleService;
        }

        Task<int?> IRequestHandler<GetPobPersonnelRequest, int?>.Handle(GetPobPersonnelRequest request, CancellationToken cancellationToken)
        {
            //var cl = Service.GetPobPersonnel(request.UserId);
            var cl = Service.GetTourId(request.UserId);
            return Task.FromResult(cl);
        }
         
    }
}