using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Security
{
    public abstract class Assignee<T> : EntityId<T>
        where T : struct
    {
        [Column(Order = 35)] 
        public virtual int UserId { get; set; }

        [Column(Order = 40, TypeName = "NVARCHAR")]
        [StringLength(16)]
        [Required]
        public virtual string Role { get; set; }

        public virtual int? TourId { get; set; }

        [NotMapped]
        public virtual Person User { get; set; }
    }
}
