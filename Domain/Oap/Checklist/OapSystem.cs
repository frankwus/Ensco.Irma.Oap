using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapSystem : Entity<int>
    {
        [Column(Order = 5)]
        [StringLength(32)]
        [Required]
        public string Code { get; set; }

        [Column(Order = 10)]
        [StringLength(1092)]
        [Required]
        public string Description { get; set; }

        [Column(Order = 15)]
        [ForeignKey("SystemGroup")]
        [Required]
        public int SystemGroupId { get; set; }
         
        public OapSystemGroup SystemGroup { get; set; }

    }
}
