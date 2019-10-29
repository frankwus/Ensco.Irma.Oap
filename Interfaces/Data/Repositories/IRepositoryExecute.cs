using Ensco.Irma.Interfaces.Domain;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IRepositoryExecute<TE,TI>
        where TE : class, IEntityId<TI>
        where TI : struct
    {
        int ExecuteSql(string sql, params object[] sqlparams);

        IEnumerable<TE> Sql(string sql, params object[] sqlparams);
    }
}
