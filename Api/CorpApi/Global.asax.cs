using System.Web.Http;

namespace Ensco.Irma.Oap.Api.Corp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(CorpWebApiConfig.Initialize);
        }
    }
}
