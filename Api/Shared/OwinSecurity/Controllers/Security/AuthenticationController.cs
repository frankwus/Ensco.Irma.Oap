using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Web.Http;
using System.Security.Claims;
using System.Web;
using Microsoft.Owin.Security;
using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Controllers.Security
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Interfaces.Services.Security;
    using Ensco.Irma.Oap.Api.Common.ActionResults;
    using Ensco.Irma.Oap.Api.Common.Models.Security;
    using Ensco.Irma.Oap.Api.Constants.Security;
    using Ensco.Irma.Oap.Api.Common.Commands.Security;
    using Ensco.Irma.Oap.Common.Api.Controllers;

    [RoutePrefix("authenticate")]
    public class AuthenticationController : OapApiController
    {
        IPeopleService PeopleService { get; set; }

        public AuthenticationController(IMediator mediator, IPeopleService peopleService, ILog logger) : base(mediator, logger)
        {

            PeopleService = peopleService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public WebApiResult<ClaimsIdentity> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return TryCatch<ClaimsIdentity>(() => null);
            }

            return TryCatch<ClaimsIdentity>(() => {

                var baseUri = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);

                var appPath = HttpContext.Current.Request.ApplicationPath;

                var properties = new Dictionary<string, string>() { { AuthenticationConstants.OwinContextCultureName, loginModel.Culture }, { ClaimTypes.Uri, $"{baseUri}/{appPath}" } };

                var identity = Mediator.Send(new LoginRequest(loginModel.LoginId, loginModel.Password, AuthenticationConstants.AuthenticationType, properties)).Result;

                HttpContext.Current.User = new GenericPrincipal(identity, identity.FindAll(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToArray());

                HttpContext.Current.GetOwinContext().Authentication.SignIn(new AuthenticationProperties { IsPersistent = loginModel.RememberMe }, identity);

                return identity;
            });

        }

        [HttpPost]
        [Route("logout")]
        [AllowAnonymous]
        public WebApiResult<bool> Logout()
        {
            return TryCatch<bool>(() => {
                Request.GetOwinContext().Authentication.SignOut(new string[] { AuthenticationConstants.AuthenticationType });
                return true;
            });
        }
    }
}
