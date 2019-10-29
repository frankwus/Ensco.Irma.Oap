using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.People
{
    using Ensco.Irma.Interfaces.Services.Security;
    using Ensco.Irma.Models.Domain.Security;
    using Ensco.Irma.Oap.Api.Common.Commands.People;

    public class GetPersonHandler : IRequestHandler<GetPersonRequest, Person>
    {
        private IPeopleService Service { get; set; }

        public GetPersonHandler(IPeopleService findingService)
        {
            Service = findingService;
        }

        Task<Person> IRequestHandler<GetPersonRequest, Person>.Handle(GetPersonRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.Get(request.PersonId);
            return Task.FromResult(cl);
        }
    }
}