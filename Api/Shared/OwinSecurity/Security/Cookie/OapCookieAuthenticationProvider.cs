using Microsoft.Owin.Security.Cookies;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SimpleInjector;
using Ensco.Irma.Oap.Api.Constants.Security;
using System.Web;
using Ensco.Irma.Interfaces.Services.Security;

namespace Ensco.Irma.Oap.Api.Common.Security.Cookie
{
    public class OapCookieAuthenticationProvider :  CookieAuthenticationProvider
    {
        public Container SimpleInjectorContainer { get; }

        public string AuthenticationType { get; }

        public string ClientId { get; }

        public OapCookieAuthenticationProvider(Container container, string authenticationType, string clientId = "Self")
        {
            SimpleInjectorContainer = container;
            AuthenticationType = authenticationType;
            ClientId = clientId;
        }


        public override Task ValidateIdentity(CookieValidateIdentityContext context)
        {
            var validated = false;
             
            var identity = context.Identity;

            if (identity == null)
            {
                // Clear the identity.
                context.RejectIdentity();
                return Task.FromResult<object>(null);
            }

            var userLogin = GetClaimValue(identity, ClaimTypes.NameIdentifier);
            var culturename = GetClaimValue(identity, AuthenticationConstants.OwinContextCultureName);

            var peopleService = SimpleInjectorContainer.GetInstance<IPeopleService>();
            var user = peopleService.GetByLogin(userLogin);

            validated = (user != null);

            if (!validated)
            { 
                context.RejectIdentity();
                return Task.FromResult<object>(null);
            }

            var nIdentity = peopleService.ValidateAndCreateClaim(user, AuthenticationType, context.Properties.Dictionary);
            
            context.OwinContext.Set<ClaimsIdentity>(AuthenticationConstants.EnscoIdentity, nIdentity);

            context.OwinContext.Set<string>(AuthenticationConstants.OwinContextCultureName, culturename); 

            return base.ValidateIdentity(context);
        }

       
        public override void ResponseSignOut(CookieResponseSignOutContext context)
        {
            context.CookieOptions.Path = TenantCookiePath();
            base.ResponseSignOut(context);
        }

        public static string TenantCookiePath()
        {
            const string basePath = "/";
            var slug = "";
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Request.Url.Segments.Count() > 1)
                {
                    slug = HttpContext.Current.Request.Url.Segments[1];
                }
            }
            if (!string.IsNullOrEmpty(slug))
            {
                slug = slug.Replace("/", "");
            }

            return basePath + slug;
        }

        private string GetClaimValue(ClaimsIdentity identity, string claimType)
        {
            Claim claim = identity.Claims.FirstOrDefault(c => (c.Type == claimType));
            if (claim != null)
            {
                return claim.Value;
            }
            return null;
        }
          

        public override void ResponseSignedIn(CookieResponseSignedInContext context)
        {
            context.Options.CookiePath = TenantCookiePath();
            base.ResponseSignedIn(context);
        }

        public override void ResponseSignIn(CookieResponseSignInContext context)
        {
            context.Options.CookiePath = TenantCookiePath();
            base.ResponseSignIn(context);
        }
    }
}