using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Workflow
{
    public class Workflow : Entity<int>
    {
        [Column(Order=3)]
        [Required]
        public int Major { get; set; }

        [Column(Order = 4)]
        [Required]
        public int Minor { get; set; }

        [Column(Order = 5)]
        [Required]
        public int ChecklistLayoutId { get; set; }

        [Column(Order = 6)]
        [Required]
        public bool Active{ get; set; }

        [Column(Order = 7)]
        [StringLength(128)]
        [Required]
        public string Assembly { get; set; }

        [Column(Order = 8)]
        [StringLength(128)]
        [Required]
        public string Type { get; set; }

        [Column(Order = 9, TypeName = "NVARCHAR")]
        [StringLength(1024)]
        public string Description { get; set; }

        [Column(Order = 10, TypeName = "TEXT")]
        public string ActivityXaml { get; set; } 

        [Column(Order = 11)]
        public WorkflowState WorkflowState { get; set; }
    }
}
