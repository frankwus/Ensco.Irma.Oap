using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Oap.Api.Common.ActionResults;
using MediatR;
using System;
using System.Runtime.CompilerServices;
using System.Web.Http;

namespace Ensco.Irma.Oap.Common.Api.Controllers
{
    //[OapWebAuthorization]
    public class OapApiController: ApiController
    {
        protected IMediator Mediator { get; set; }

        protected ILog Logger { get; private set; }

        public OapApiController(IMediator mediator, ILog logger)
        {
            Mediator = mediator;
            Logger = logger;
        }

        protected WebApiResult<T> TryCatch<R,T>(R  command, [CallerMemberName] string methodName = null)
            where R:IRequest<T>
        {
            var result = new WebApiResult<T>();
            try
            {
                T val = Mediator.Send(command).Result;
                result.Data = val;
            }
            catch (Exception ex)
            {
                var eMsg = GetErrorMessage(ex);

                result.SetError($"Error in method {methodName} - {eMsg}", ex);
            }
            return result;
        }

        protected WebApiResult<T> TryCatch<T>(Func<T> func, [CallerMemberName] string methodName = null) 
        {
            var result = new WebApiResult<T>();
            try
            {
                T val = func();
                result.Data = val;
            }
            catch (Exception ex)
            {
                var eMsg = GetErrorMessage(ex);
              
                result.SetError($"Error in method {methodName} - {eMsg}", ex);
            }
            return result;
        }

        protected string GetErrorMessage(Exception ex)
        {
            var errorMsg = ex?.Message;
            if (ex?.InnerException != null)
            {
                errorMsg = ex.InnerException.Message;
            }

            return errorMsg;

        }

        

    }
}