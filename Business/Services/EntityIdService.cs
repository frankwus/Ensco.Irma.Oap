using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Domain;
using Ensco.Irma.Interfaces.Services;
using Ensco.Irma.Interfaces.Services.Logging;
using System.Collections.Generic;
using System.Data.Entity;

namespace Ensco.Irma.Services
{
    public abstract class EntityIdService<TContext, TRepository, TEntity, TId> : IEntityIdService<TEntity, TId>
        where TRepository : IBaseIdRepository<TEntity, TId>
        where TContext : DbContext, IDbContext
        where TEntity : Models.Domain.EntityId<TId>
        where TId : struct
    {
        protected ILog Log { get; }

        protected EntityIdService(TRepository repository)
        {
            Repository = repository;
        }

        protected EntityIdService(TRepository repository, ILog log)
        {
            Repository = repository;
            Log = log;
        }

        protected TRepository Repository { get; }

        public virtual TId Add(TEntity entity)
        {
            return Repository.Add(entity);
        }

        public virtual bool Delete(IEnumerable<TEntity> entities)
        {
            return Repository.Delete(entities);
        }

        public virtual bool Delete(TEntity entity)
        {
            return Repository.Delete(entity);
        }

        public virtual bool Delete(TId id)
        {
            return Repository.Delete(id);
        }

        public virtual TEntity Get(TId id)
        {
            return Repository.Get(id);
        }

        public virtual TEntity Get(params object[] ids)
        {
            return Repository.Get(ids);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual int Save(TEntity entity)
        {
            return Repository.SaveChanges(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return Repository.Update(entity);
        }

        public int ExecuteSql(string sql, params object[] sqlparams)
        {
            return Repository.ExecuteSql(sql, sqlparams);
        }

        public IEnumerable<TEntity> Sql(string sql, params object[] sqlparams)
        {
            return Repository.Sql(sql, sqlparams);
        }

        public int SendEmail(string to, string subject, string body, string cc = "")
        {
            return Repository.SendEmail(to, subject, body, cc);
        }
    }
}
