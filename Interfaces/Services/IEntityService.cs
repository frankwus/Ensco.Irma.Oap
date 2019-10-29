using Ensco.Irma.Interfaces.Domain;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Services
{
    public interface IEntityService<TEntity,TId>: IEntityIdService<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        TEntity GetByName(string name);
    }
}