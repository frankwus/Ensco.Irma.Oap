namespace Ensco.Irma.Interfaces.Domain
{
    public interface IHistoricalEntity<T> : IEntity<T>, IEntityDates
        where T : struct
    {

    }
}
