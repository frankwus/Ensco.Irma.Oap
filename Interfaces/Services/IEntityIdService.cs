using Ensco.Irma.Interfaces.Domain;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Services
{
    public interface IEntityIdService<TEntity, TId>
       where TEntity : IEntityId<TId>
       where TId : struct
    {
        TId Add(TEntity entity);

        TEntity Get(TId id);

        TEntity Get(params object[] ids);

        IEnumerable<TEntity> GetAll();

        int Save(TEntity entity);

        bool Delete(IEnumerable<TEntity> entities);

        bool Delete(TEntity entity);

        bool Delete(TId id);

        TEntity Update(TEntity entity);

        int ExecuteSql(string sql, params object[] sqlparams);

        IEnumerable<TEntity> Sql(string sql, params object[] sqlparams);

        int SendEmail(string to, string subject, string body, string cc = "");
    }
}