using Ensco.Irma.Interfaces.Domain;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IRespositoryWrite<TE, TI>
        where TE : class, IEntityId<TI>
        where TI : struct
    {
        TI Add(TE entity);

        TE Update(TE entity);

        bool Delete(TI id);

        bool Delete(TE entity);

        bool Delete(IEnumerable<TE> entities);
    }
}
