using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    using Ensco.Irma.Models.Domain.Security;

    public abstract class Assignees<T> : EntityId<T>
        where T : struct
    {
        [Column(Order = 35)]
        [ForeignKey("Assignee")]
        public virtual int AssigneeId { get; set; }

        public Person Assignee { get; set; }

        [Column(Order = 40, TypeName = "NVARCHAR")]
        [StringLength(16)]
        [Required]
        public virtual string Role { get; set; }
    }
}
