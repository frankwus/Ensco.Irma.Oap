
using Ensco.Irma.Oap.Api.Common.Security;
using Ensco.Irma.Oap.Api.Common.Security.Cookie;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

namespace Ensco.Irma.Oap.Api.Common.Extension
{
    public static class OapWebApiExtentions
    {
        public static IAppBuilder UseOapCookieAuthentication(this IAppBuilder app, CookieAuthenticationOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }

            app.Use(typeof(OapCookieAuthenticationMiddleware), app, options);
            app.UseStageMarker(PipelineStage.Authenticate);
            return app;
        }

        public static IAppBuilder UseOapOwinMiddleware(this IAppBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }

            app.Use(typeof(OapAuthorizationOwinMiddleware));
            app.UseStageMarker(PipelineStage.Authorize);
            return app;
        }
    }
}