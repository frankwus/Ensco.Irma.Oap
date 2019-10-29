using Ensco.Irma.Interfaces.Domain;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IHistoricalBaseRepository<TE, TI> : IBaseRepository<TE, TI>
         where TE : class, IHistoricalEntity<TI>
       where TI : struct
    {
        IEnumerable<TE> GetAll(DateTime startDate, DateTime endDate);
    }
}