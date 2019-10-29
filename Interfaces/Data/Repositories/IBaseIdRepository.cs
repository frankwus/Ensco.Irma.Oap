using Ensco.Irma.Interfaces.Domain;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IBaseIdRepository<TE, TI> : IRepositoryRead<TE, TI>, IRespositoryWrite<TE, TI>, IRepositoryExecute<TE, TI>
        where TE : class, IEntityId<TI>
        where TI : struct
    {
        int SaveChanges(TE entity);

        int SendEmail(string to, string subject, string body, string cc = "");

        bool HasChanged(TE entity);
    }
     
}