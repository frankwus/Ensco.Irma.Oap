using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Domain;
using Ensco.Irma.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    public abstract class HistoricalBaseIdRepository<TC, TE, TI> : BaseIdRepository<TC, TE, TI>, IHistoricalBaseIdRepository<TE, TI>
       where TC : DbContext, IDbContext, IExecuteSql
       where TE : class, IHistoricalEntityId<TI>
       where TI : struct
    {
        public HistoricalBaseIdRepository(TC context, ILog log) : base(context, log)
        {
        }

        public virtual IEnumerable<TE> GetAll(DateTime startDate, DateTime endDate)
        {
            return (from it in AllItems
                    where it.StartDateTime <= startDate && it.EndDateTime >= endDate
                    select it).ToList();
        }
    }
}
