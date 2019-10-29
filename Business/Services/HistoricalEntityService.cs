using Ensco.Irma.Data.Repositories;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Domain;
using Ensco.Irma.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Ensco.Irma.Services
{
    public abstract class HistoricalEntityService<TContext, TRepository, TEntity, TId> : EntityService<TContext, TRepository, TEntity, TId> , IHistoricalEntityService<TEntity,TId>
        where TRepository :  IHistoricalBaseRepository<TEntity, TId>
        where TContext : DbContext, IDbContext
        where TEntity: Models.Domain.HistoricalEntity<TId>
        where TId: struct
    {
        protected HistoricalEntityService(TRepository repository):base(repository)
        {
        }

        public virtual IEnumerable<TEntity> GetAll(DateTime startDate, DateTime endDate)
        {
            return Repository.GetAll(startDate, endDate);
        }
    }
}
