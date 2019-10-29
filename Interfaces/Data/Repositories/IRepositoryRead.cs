using Ensco.Irma.Interfaces.Domain;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IRepositoryRead<TE, TI>
        where TE : class, IEntityId<TI>
        where TI : struct
    {
        TE Get(TI id);

        TE Get(params object[] id);

        IEnumerable<TE> GetAll();
    }
}
