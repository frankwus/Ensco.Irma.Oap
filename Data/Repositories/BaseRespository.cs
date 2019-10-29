using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Domain;
using Ensco.Irma.Interfaces.Services.Logging;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    public abstract class BaseRepository<TC, TE, TI> : BaseIdRepository<TC, TE, TI> , IBaseRepository<TE, TI> 
        where TC: DbContext, IDbContext, IExecuteSql
        where TE: class, IEntity<TI>
        where TI: struct
    {
        public BaseRepository(TC context, ILog log):base(context, log)
        {
            
        }

        public virtual TE GetByName(string name)
        {
            var r = AllItems.FirstOrDefault(i => i.Name.Equals(name,System.StringComparison.InvariantCultureIgnoreCase));

            return r;
        } 
    }

}
