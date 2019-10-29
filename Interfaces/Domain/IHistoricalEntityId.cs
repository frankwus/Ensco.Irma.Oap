using System;

namespace Ensco.Irma.Interfaces.Domain
{
    public interface IHistoricalEntityId<T> : IEntityId<T>, IEntityDates
       where T : struct
    { 
    }
}
