using Ensco.Irma.Models.Domain.IRMA;
using System.Data.Entity.ModelConfiguration;


namespace Ensco.Irma.Data.Mappings
{
    public class PobPersonnelMap : EntityTypeConfiguration<PobPersonnel>
    {
        public PobPersonnelMap()
        {

            this.ToTable("POB_RigPersonnel");
            this.Property(t => t.PobPersonId).HasColumnName("PassportId");
            this.Property(t => t.PersonnelTypeId).HasColumnName("PersonnelType");
            this.Property(t => t.TourId).HasColumnName("Tour");
            this.Property(t => t.PobStatusId).HasColumnName("Status");
            this.Property(t => t.StartDateTime).HasColumnName("DateStart");
            this.Property(t => t.EndDateTime).HasColumnName("DateEnd");
            this.Property(t => t.EstimatedLeave).HasColumnName("DateEstimatedLeave");
        }
    }
}
