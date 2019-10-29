using MediatR;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Security
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Interfaces.Services.Security;
    using Ensco.Irma.Oap.Api.Common.Commands.Security;

    public class LoginHandler : IRequestHandler<LoginRequest, ClaimsIdentity>
    {
        public LoginHandler(IPeopleService peopleService, ILog logger)
        {
            PeopleService = peopleService;
            Logger = logger;
        }

        public IPeopleService PeopleService { get; }

        public ILog Logger { get; }

        async Task<ClaimsIdentity> IRequestHandler<LoginRequest, ClaimsIdentity>.Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var identity = PeopleService.GetIdentity(request.LoginId, request.Password, request.AuthenticationType, request.Properties); 

            return identity;
        }
    }
}