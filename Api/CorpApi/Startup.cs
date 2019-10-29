using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Ensco.Irma.Oap.Api.Constants.Security;
using Ensco.Irma.Oap.Api.Common;
using Ensco.Irma.Oap.Api.Common.Extension;

[assembly: OwinStartup(typeof(Ensco.Irma.Oap.Api.Corp.Startup))]
namespace Ensco.Irma.Oap.Api.Corp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            CorpWebApiConfig.Initialize(config);

            StartupConfiguration.Authorization(app, CorpWebApiConfig.Instance.Value.Container, AuthenticationConstants.CorpApiLoginPath);
            
            app.UseOapOwinMiddleware();

            //app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
             
            //config.EnsureInitialized();

        }

        
    }
}