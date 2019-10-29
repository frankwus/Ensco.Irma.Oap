using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Data.Context
{
     public interface IExecuteSql
    {
        int ExecuteSql(string sql, params object[] sqlparams);

        IEnumerable<T> Sql<T>(string sql, params object[] sqlparams);
    }
}
