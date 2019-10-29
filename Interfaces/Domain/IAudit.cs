using System; 

namespace Ensco.Irma.Interfaces.Domain
{
    public interface IAudit
    {
        DateTime UpdatedDateTime { get; set; }

        DateTime CreatedDateTime { get; set; }

        string UpdatedBy { get; set; }

        string CreatedBy { get; set; }
    }
}
