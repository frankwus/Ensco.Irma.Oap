using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapEquipment : Entity<int>
    {
        [Column(Order = 5)]
        [StringLength(1092)]
        [Required]
        public string Description { get; set; }
    }
}
