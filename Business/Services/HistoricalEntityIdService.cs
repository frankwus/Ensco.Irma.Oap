using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Domain;
using Ensco.Irma.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Ensco.Irma.Services
{
    public abstract class HistoricalEntityIdService<TContext, TRepository, TEntity, TId> : EntityIdService<TContext, TRepository, TEntity, TId>, IHistoricalEntityIdService<TEntity, TId>
       where TRepository : IHistoricalBaseIdRepository<TEntity, TId>
       where TContext : DbContext, IDbContext
       where TEntity : Models.Domain.HistoricalEntityId<TId>
       where TId : struct
    {
        protected HistoricalEntityIdService(TRepository repository) : base(repository)
        {
        }

        public virtual IEnumerable<TEntity> GetAll(DateTime startDate, DateTime endDate)
        {
            return Repository.GetAll(startDate, endDate);
        }
    }
}
