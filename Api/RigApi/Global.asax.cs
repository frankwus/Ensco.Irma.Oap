using Ensco.Irma.Oap.Api.Rig;
using System.Web.Http;

namespace Ensco.Irma.Oap.Api.Rig
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(RigWebApiConfig.Initialize);
        }
    }
}
