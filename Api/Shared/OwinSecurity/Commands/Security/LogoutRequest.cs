using MediatR;
using Microsoft.Owin.Security;

namespace Ensco.Irma.Oap.Api.Common.Commands.Security
{
    public class LogoutRequest : IRequest<bool>
    {
        public IAuthenticationManager AuthenticationManager { get; }

        public LogoutRequest(IAuthenticationManager authenticationManager)
        {
            AuthenticationManager = authenticationManager;
        }
         
    }
}