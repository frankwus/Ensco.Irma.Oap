using Ensco.Irma.Models.Domain.IRMA;
using Ensco.Irma.Models.Domain.Security;
using System.Data.Entity.ModelConfiguration;

namespace Ensco.Irma.Data.Mappings
{
    public class AdminCustomMap : EntityTypeConfiguration<AdminCustom>
    {
        public AdminCustomMap()
        {
            this.ToTable("vw_AdminCustom"); 
        }
    }
}
