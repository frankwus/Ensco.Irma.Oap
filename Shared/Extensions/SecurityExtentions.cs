using System.Linq;
using System.Security.Claims;

namespace Ensco.Irma.Extensions
{
    public static class SecurityExtentions
    {
        public static bool Compare(this ClaimsIdentity current, ClaimsIdentity compareTo, string claimType)
        {
            var currentValue = current.Claims.FirstOrDefault(c => c.Type.Equals(claimType))?.Value;
            var compareToValue = compareTo?.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? string.Empty;
            var currentAuthenticationType = current.AuthenticationType;
            var compareToAutenticationType = compareTo?.AuthenticationType ?? string.Empty;

            return ((!string.IsNullOrEmpty(currentValue) && !string.IsNullOrEmpty(compareToValue) && !string.IsNullOrEmpty(currentAuthenticationType) && !string.IsNullOrEmpty(compareToAutenticationType)))
                && (currentValue.Equals(compareToValue) && currentAuthenticationType.Equals(compareToAutenticationType));              
        }
    }
}
