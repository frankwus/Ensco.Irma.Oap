using Ensco.Irma.Interfaces.Domain;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IBaseRepository<TE, TI> : IBaseIdRepository<TE,TI>
        where TE : class, IEntity<TI>
        where TI : struct
    {
        TE GetByName(string name); 
    }
}