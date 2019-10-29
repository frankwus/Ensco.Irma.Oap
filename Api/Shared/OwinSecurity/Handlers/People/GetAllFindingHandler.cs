
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Common.People
{
    using Ensco.Irma.Interfaces.Services.Security;
    using Ensco.Irma.Models.Domain.Security;
    using Ensco.Irma.Oap.Api.Common.Commands.Common.People;

    public class GetAllPeopleHandler : IRequestHandler<GetAllPeopleRequest, IEnumerable<Person>>
    {
        private IPeopleService Service { get; set; }

        public GetAllPeopleHandler(IPeopleService peopleService)
        {
            Service = peopleService;
        }

        Task<IEnumerable<Person>> IRequestHandler<GetAllPeopleRequest, IEnumerable<Person>>.Handle(GetAllPeopleRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAll();
            return Task.FromResult(cl);
        }
    }
}