
namespace Ensco.Irma.Interfaces.Domain
{
    public interface IDbContext
    {
        object Model { get; set; }

        void SetAuditValues<TE>(TE entity, bool update = true)
            where TE : class, IAudit;
    }
}