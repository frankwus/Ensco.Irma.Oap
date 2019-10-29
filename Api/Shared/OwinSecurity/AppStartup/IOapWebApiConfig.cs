using System.Web.Http;

namespace Ensco.Irma.Oap.Api.Common.AppStartup
{
    public interface IOapWebApiConfig
    {
        void Register(HttpConfiguration config);
    }
}
