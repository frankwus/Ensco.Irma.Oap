using Ensco.Irma.Models.Domain.IRMA;
using Ensco.Irma.Models.Domain.Security;
using System.Collections.Generic;
using System.Security.Claims;

namespace Ensco.Irma.Interfaces.Services.Security
{

    public interface IPeopleService  : IEntityService<Person, int>
    { 
        Person GetByLogin(string login);

        ClaimsIdentity GetIdentity(string login, string password, string authenticationType, IDictionary<string, string> properties);
         
        ClaimsIdentity ValidateAndCreateClaim(Person personLoggedIn, string authenticationType, IDictionary<string, string> properties);

        PobPersonnel GetPobPersonnel(int userId);
        int? GetTourId(int userId);
    }
}
