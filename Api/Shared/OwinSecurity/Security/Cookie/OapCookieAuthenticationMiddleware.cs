using Microsoft.Owin;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

namespace Ensco.Irma.Oap.Api.Common.Security.Cookie
{
    /// <summary>
    /// Copied from Microsoft.Owin.Security.Cookies.CookieAuthenticationMiddleware in Katana Project in CodePlex. 
    /// </summary>
    public class OapCookieAuthenticationMiddleware : AuthenticationMiddleware<CookieAuthenticationOptions>
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a <see cref="OapCookieAuthenticationMiddleware"/>
        /// </summary>
        /// <param name="next">The next middleware in the OWIN pipeline to invoke</param>
        /// <param name="app">The OWIN application</param>
        /// <param name="options">Configuration options for the middleware</param>
        public OapCookieAuthenticationMiddleware(OwinMiddleware next, IAppBuilder app, Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions options) : base(next, options)
        {
            Options.Provider = Options.Provider ?? new CookieAuthenticationProvider();

            if (String.IsNullOrEmpty(Options.CookieName))
            {
                Options.CookieName = CookieAuthenticationDefaults.CookiePrefix + Options.AuthenticationType;
            }

            _logger = app.CreateLogger<OapCookieAuthenticationMiddleware>();

            if (Options.TicketDataFormat == null)
            {
                IDataProtector dataProtector = app.CreateDataProtector(
                    typeof(OapCookieAuthenticationMiddleware).FullName,
                    Options.AuthenticationType, "v1");

                Options.TicketDataFormat = new TicketDataFormat(dataProtector);
            }
            if (Options.CookieManager == null)
            {
                Options.CookieManager = new ChunkingCookieManager();
            }
        }

        /// <summary>
        /// Provides the <see cref="AuthenticationHandler"/> object for processing authentication-related requests.
        /// </summary>
        /// <returns>An <see cref="AuthenticationHandler"/> configured with the <see cref="CookieAuthenticationOptions"/> supplied to the constructor.</returns>
        protected override AuthenticationHandler<CookieAuthenticationOptions> CreateHandler()
        {
            return new OapCookieAuthenticationHandler(_logger);
        }
    }
}