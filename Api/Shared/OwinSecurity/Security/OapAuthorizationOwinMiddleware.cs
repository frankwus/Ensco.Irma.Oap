using Ensco.Irma.Extensions;
using Ensco.Irma.Oap.Api.Constants.Security;
using Microsoft.Owin;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Ensco.Irma.Oap.Api.Common.Security
{
    internal class OapAuthorizationOwinMiddleware : OwinMiddleware
    {
        /// <summary>
        /// Initializes an instance of the Oap Authorization Owin Middleware.
        /// </summary>
        /// <param name="next"></param>
        public OapAuthorizationOwinMiddleware(OwinMiddleware next)
            : base(next)
        { }

        /// <summary>
        /// Invokes the Oap Authorization Owin Middleware in the Owin pipeline.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task Invoke(IOwinContext context)
        {
            // Get the identity and cultureName from the Owin environment.
            var identity = context.Get<ClaimsIdentity>(AuthenticationConstants.EnscoIdentity);
            string cultureName = context.Get<string>(AuthenticationConstants.OwinContextCultureName);

            if (identity != null)  
            {
               //var identity = new GenericPrincipal()
                // Create an Generic Principal using the Identity.
                var principal = new ClaimsPrincipal(identity);
                //context.Authentication.SignIn(new Microsoft.Owin.Security.AuthenticationProperties() { IsPersistent = true }, identity);
                //context.Request.Set(AuthenticationConstants.AuthenticationType, principal);
                if (HttpContext.Current != null)
                {
                    var currentPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;
                    var currentIdentity = currentPrincipal.Identity as ClaimsIdentity;

                    if (!identity.Compare(currentPrincipal.Identity as ClaimsIdentity, ClaimTypes.NameIdentifier))
                    {
                        AppDomain.CurrentDomain.SetThreadPrincipal(principal);
                        Thread.CurrentPrincipal = principal;
                        if (HttpContext.Current != null)
                        {
                            HttpContext.Current.User = principal;
                        }
                    }
                }
            }

            try
            {
                await Next.Invoke(context);
            }
            catch (Exception)
            {
                await Task.FromResult<object>(null);
            }
        }
    }
}