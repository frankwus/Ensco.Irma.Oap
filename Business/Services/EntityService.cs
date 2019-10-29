using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Domain;
using Ensco.Irma.Interfaces.Services;
using Ensco.Irma.Interfaces.Services.Logging;
using System.Data.Entity;

namespace Ensco.Irma.Services
{
    public abstract class EntityService<TContext, TRepository, TEntity, TId> : EntityIdService<TContext, TRepository, TEntity, TId>, IEntityService<TEntity,TId>
        where TRepository :  IBaseRepository<TEntity, TId>
        where TContext : DbContext, IDbContext
        where TEntity: Models.Domain.Entity<TId>
        where TId: struct
    {
        protected EntityService(TRepository repository, ILog log): base(repository, log)
        {
        }

        protected EntityService(TRepository repository) : base(repository)
        {
        }

        public virtual TEntity GetByName(string name)
        {
            return Repository.GetByName(name);
        }

       

    }
}
