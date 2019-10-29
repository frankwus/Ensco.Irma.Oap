using Ensco.Irma.Oap.Api.Constants.Security;
using Ensco.Irma.Oap.Api.Common.Security.Cookie;
using Ensco.Irma.Oap.Api.Common.Extension;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using SimpleInjector;
using System; 

namespace Ensco.Irma.Oap.Api.Common
{
    public class StartupConfiguration
    {
        public static void Authorization(IAppBuilder app, Container container, string apiPath)
        {
            var authenticationType = AuthenticationConstants.AuthenticationType;

            var basePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

            app.UseOapCookieAuthentication(new CookieAuthenticationOptions
            {
                CookieName = AuthenticationConstants.CookieName,
                CookieDomain = AuthenticationConstants.CookieDomain,
                CookieSecure = CookieSecureOption.Always,
                AuthenticationType = authenticationType,
                LoginPath = new PathString(apiPath),
                Provider = new OapCookieAuthenticationProvider(container, authenticationType),
                SlidingExpiration = true,
                ExpireTimeSpan = AuthenticationConstants.CookieExpirationTimeSpan
            });
        }
    }
}
