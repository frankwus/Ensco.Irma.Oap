using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices.AccountManagement;
using System.Security.Claims;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Data.Repositories.Irma;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Interfaces.Services.Security;
using Ensco.Irma.Models.Domain.IRMA;
using Ensco.Irma.Models.Domain.Security;
using Ensco.Utilities;

namespace Ensco.Irma.Services.Security
{
    public class PeopleService : EntityService<IrmaOapDbContext, IPeopleRepository, Person, int>, IPeopleService
    {
        public const string PasswordSecurityKey = "ENSCO1@#$";

        public PeopleService(IPeopleRepository repository,
                             IPobPersonnelRepository pobPersonnelRepository, ILog log) : base(repository, log)
        {
            PobPersonnelRepository = pobPersonnelRepository;
        }

        public IPobPersonnelRepository PobPersonnelRepository { get; }

        public Person GetByLogin(string login)
        {
            return Repository.GetByLogin(login);
        }

        public ClaimsIdentity GetIdentity(string login, string password, string authenticationType, IDictionary<string, string> properties)
        {
            ClaimsIdentity identity = ValidateAndCreateClaim(Repository.GetByLogin(login), authenticationType, properties);
            
            return identity; 
        }

        public ClaimsIdentity ValidateAndCreateClaim(Person personLoggedIn, string password, string authenticationType, IDictionary<string, string> properties)
        {
            ClaimsIdentity identity = null;

            if (personLoggedIn == null)
            {
                return identity;
            }

            var isAuthenticated = false;

            if (personLoggedIn.IsADUser??false)
            {
                var principalContext = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["AD"]);
                try
                {
                    isAuthenticated = principalContext.ValidateCredentials(personLoggedIn.Login, password, ContextOptions.Negotiate);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);

                    isAuthenticated = false;
                }
            }
            else
            {
                // Database authentication
                if (EnscoCryptography.Decrypt(personLoggedIn.Login, personLoggedIn.Password) == password)
                {
                    isAuthenticated = true;
                }
            }

            identity = new ClaimsIdentity(authenticationType);

            identity.AddClaim(new Claim(ClaimTypes.Name, personLoggedIn.Login));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, personLoggedIn.Login));
            identity.AddClaim(new Claim(ClaimTypes.GivenName, personLoggedIn.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.Surname, personLoggedIn.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.PrimarySid, personLoggedIn.Id.ToString()));

            //personLoggedIn.Roles.ToList().ForEach(ur => {
            //    identity.AddClaim(new Claim(ClaimTypes.Role, ur.Role.Name));
            //    });

            foreach (var kv in properties)
            {
                identity.AddClaim(new Claim(kv.Key, kv.Value));
            }

            return identity;
        }

        public ClaimsIdentity ValidateAndCreateClaim(Person personLoggedIn, string authenticationType, IDictionary<string, string> properties)
        {
            ClaimsIdentity identity = null;

            if (personLoggedIn == null)
            {
                return identity;
            } 

            identity = new ClaimsIdentity(authenticationType);

            identity.AddClaim(new Claim(ClaimTypes.Name, personLoggedIn.Login));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, personLoggedIn.Login));
            identity.AddClaim(new Claim(ClaimTypes.GivenName, personLoggedIn.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.Surname, personLoggedIn.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.PrimarySid, personLoggedIn.Id.ToString()));
             
            //personLoggedIn.Roles.ToList().ForEach(ur => {
            //    identity.AddClaim(new Claim(ClaimTypes.Role, ur.Role.Name));
            //    });

            foreach(var kv in properties)
            {
               identity.AddClaim(new Claim(kv.Key, kv.Value));
            }

            return identity;
        }
       

        public PobPersonnel GetPobPersonnel(int userId)
        {
            return PobPersonnelRepository.GetPobPersonnel(userId);
        }

        public int? GetTourId(int userId)
        {
            return PobPersonnelRepository.GetTourId(userId);
        }


    }
}
