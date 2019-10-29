using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapChecklistLayoutColumn : Entity<int>
    {
        [Column(Order = 5)]
        [StringLength(128)]
        [Required]
        public string DisplayName { get; set; }

        [Column(Order = 10)]
        [StringLength(1024)]
        [Required]
        public string Description { get; set; }

        [Column(Order = 15)] 
        [Required]
        public bool IsYesNoNa { get; set; }

        [Column(Order = 20)] 
        [Required]
        public int YesNoNaCount { get; set; }

        [Column(Order = 25)] 
        public string YesNoNaPrefix { get; set; }

        [Column(Order = 30)]
        [ForeignKey("ChecklistLayout")]
        public int ChecklistLayoutId { get; set; }

        [JsonIgnore]
        public OapChecklistLayout ChecklistLayout { get; set; }

    }
}