namespace Ensco.Irma.Interfaces.Domain
{
    public interface IEntity<T>  : IEntityId<T>
        where T : struct
    { 
        string Name { get; set; }
    }
}
