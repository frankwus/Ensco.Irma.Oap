using Ensco.Irma.Interfaces.Domain;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Services
{
    public interface IHistoricalEntityService<TEntity, TId> : IEntityService<TEntity, TId>
        where TEntity : IHistoricalEntity<TId>
        where TId : struct
    {
        IEnumerable<TEntity> GetAll(DateTime startDate, DateTime endDate);
    }
}