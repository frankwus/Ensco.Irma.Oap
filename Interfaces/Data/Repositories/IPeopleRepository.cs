using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Models.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IPeopleRepository : IBaseRepository<Person, int>
    { 
        Person GetByLogin(string login);

        Person GetByLogin(string login, string password);
    }
}
