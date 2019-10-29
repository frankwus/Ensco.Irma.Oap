using Ensco.Irma.Models.Domain.IRMA;
using Ensco.Irma.Models.Domain.Security;
using System.Data.Entity.ModelConfiguration;


namespace Ensco.Irma.Data.Mappings
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {

            this.ToTable("Master_Users");
            this.Property(t => t.Name).HasColumnName("DisplayName");
            this.Property(t => t.IsADUser).HasColumnName("ADUser");
        }
    }
}
