using System;

namespace Ensco.Irma.Oap.Api.Constants.Security
{
    public class AuthenticationConstants
    {
        public const string AuthenticationType = "oap";

        public const string CookieName = "EnscoAuthenticationType";

        public const string CookieDomain = ".ensco.com";

        public const string RigApiLoginPath = "/authenticate/Login";

        public const string CorpApiLoginPath = "/authenticate/Login";

        public const string EnscoIdentity = "ensco.identity";

        public const string OwinContextCultureName = "ensco.culture";

        public static TimeSpan CookieExpirationTimeSpan { get; } = TimeSpan.FromHours(0.5);
    }
}
