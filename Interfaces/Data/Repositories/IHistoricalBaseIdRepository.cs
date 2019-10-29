using Ensco.Irma.Interfaces.Domain;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IHistoricalBaseIdRepository<TE, TI> : IBaseIdRepository<TE, TI>
          where TE : class, IHistoricalEntityId<TI>
        where TI : struct
    {
        IEnumerable<TE> GetAll(DateTime startDate, DateTime endDate);
    }
}