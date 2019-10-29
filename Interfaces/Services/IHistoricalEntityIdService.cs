using Ensco.Irma.Interfaces.Domain;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Services
{
    public interface IHistoricalEntityIdService<TEntity, TId> : IEntityIdService<TEntity, TId>
      where TEntity : IHistoricalEntityId<TId>
      where TId : struct
    {
        IEnumerable<TEntity> GetAll(DateTime startDate, DateTime endDate);
    }
}