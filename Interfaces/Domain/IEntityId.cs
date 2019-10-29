namespace Ensco.Irma.Interfaces.Domain
{
    public interface IEntityId<T> : IAudit
       where T : struct
    {
        T Id { get; set; }

        string SiteId { get; set; }
    }
}
