using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Security;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    public class PeopleRepository : BaseRepository<IrmaDbContext, Person, int>, IPeopleRepository
    {
        public PeopleRepository(IIrmaDbContext context, ILog log) : base((IrmaDbContext)context, log)
        {

        }

        public Person GetByLogin(string login)
        {
            return AllItems.FirstOrDefault(p => p.Login.Equals(login));
        }

        public Person GetByLogin(string login, string password)
        {
            var user = GetByLogin(login); 

            return AllItems.FirstOrDefault(p => p.Login.Equals(login) && p.Password.Equals(password));
        }


    }
}
