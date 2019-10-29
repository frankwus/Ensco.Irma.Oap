using Ensco.Irma.Logging;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Tracing;

namespace Ensco.Irma.Oap.Api.Common.ActionFilters
{
    public class LoggingFilter : ActionFilterAttribute
    {
        private HttpConfiguration Config { get; set; }

        public LoggingFilter(HttpConfiguration config)
        {
            Config = config;
        }
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            Config.Services.Replace(typeof(ITraceWriter), new LogTraceWriter(Log.GetLogger(typeof(LoggingFilter))));
            var trace = Config.Services.GetTraceWriter();
            trace.Info(filterContext.Request, "Controller : " + filterContext.ControllerContext.ControllerDescriptor.ControllerType.FullName + System.Environment.NewLine + "Action : " + filterContext.ActionDescriptor.ActionName, "JSON", filterContext.ActionArguments);
        }

    }
}