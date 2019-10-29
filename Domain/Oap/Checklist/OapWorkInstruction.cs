using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapWorkInstruction : EntityId<int>
    {

        [Column(Order = 5)]
        [StringLength(256)]
        [Required]
        public string Title { get; set; }

        [Column(Order = 10)]
        [StringLength(128)]
        [Required]
        public string InstructionNumber { get; set; }

        [Column(Order = 15)]
        [StringLength(128)]
        [Required]
        public string ReferenceId { get; set; }
    }
}
