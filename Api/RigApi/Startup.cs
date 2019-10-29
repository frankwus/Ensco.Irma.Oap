using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Ensco.Irma.Oap.Api.Constants.Security;
using Ensco.Irma.Oap.Api.Common.Extension;
using Ensco.Irma.Oap.Api.Common;

[assembly: OwinStartup(typeof(Ensco.Irma.Oap.Api.Rig.Startup))]
namespace Ensco.Irma.Oap.Api.Rig
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            RigWebApiConfig.Initialize(config);

            StartupConfiguration.Authorization(app, RigWebApiConfig.Instance.Value.Container, AuthenticationConstants.RigApiLoginPath);

            app.UseOapOwinMiddleware();

            //app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);

            //config.EnsureInitialized();

        }

       
    }
}