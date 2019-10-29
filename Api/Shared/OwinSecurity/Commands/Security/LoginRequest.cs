using MediatR;
using System.Collections.Generic;
using System.Security.Claims;

namespace Ensco.Irma.Oap.Api.Common.Commands.Security
{
    public class LoginRequest : IRequest<ClaimsIdentity>
    {
        public LoginRequest(string loginId, string password, string authenticationType, IDictionary<string, string> properties)
        {
            LoginId = loginId;
            Password = password;
            AuthenticationType = authenticationType;
            Properties = properties;
        }

        public IDictionary<string, string> Properties { get; }
 

        public string LoginId { get;  }

        public string Password { get; }

        public string AuthenticationType { get; }
    }
}