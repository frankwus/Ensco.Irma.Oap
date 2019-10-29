using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;
using Ensco.Irma.Extensions;
using Ensco.Irma.Oap.Api.Constants.Security;
 

namespace Ensco.Irma.Oap.Api.Common.Security
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class OapWebAuthorizationAttribute : AuthorizeAttribute
    { 
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var owinContext = actionContext.Request.GetOwinContext();
            var enscoIdentity = owinContext.Get<ClaimsIdentity>(AuthenticationConstants.EnscoIdentity);
            if ((enscoIdentity != null) && !enscoIdentity.Compare(actionContext.ControllerContext.RequestContext.Principal.Identity as ClaimsIdentity, ClaimTypes.NameIdentifier))
            {
                actionContext.ControllerContext.RequestContext.Principal = new ClaimsPrincipal(enscoIdentity);
            }
            return  base.IsAuthorized(actionContext) && (actionContext.ControllerContext.RequestContext.Principal != null);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            return; 
        }
    }
}