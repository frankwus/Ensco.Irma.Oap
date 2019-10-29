using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Security
{
    using Ensco.Irma.Oap.Api.Common.Commands.Security;

    public class LogoutHandler : IRequestHandler<LogoutRequest, bool>
    {

        Task<bool> IRequestHandler<LogoutRequest, bool>.Handle(LogoutRequest request, CancellationToken cancellationToken)
        {
            request.AuthenticationManager.SignOut();

            return Task.FromResult<bool>(true);
        }
    }
}