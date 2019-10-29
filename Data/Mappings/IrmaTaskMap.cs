using Ensco.Irma.Models.Domain.IRMA;
using System.Data.Entity.ModelConfiguration;


namespace Ensco.Irma.Data.Mappings
{
    public class IrmaTaskMap : EntityTypeConfiguration<IrmaTask>
    {
        public IrmaTaskMap()
        {

            ToTable("Tasks");
            Property(t => t.Source).HasColumnName("SourceForm");
            Property(t => t.SourceId).HasColumnName("SourceFormId");
            Property(t => t.SourceUrl).HasColumnName("SourceFormUrl");
            Property(t => t.AssigneeId).HasColumnName("AssigneeUserId");
            Property(t => t.Comment).HasColumnName("Message");
            Property(t => t.AssignedDateTime).HasColumnName("AssignedAt");
            Property(t => t.DueDate).HasColumnName("DueDate");
            Property(t => t.Status).HasColumnName("Status");
        }
    }
}
