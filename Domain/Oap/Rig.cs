using Ensco.Irma.Models.Domain.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap
{
    [NonOapEntity]

    [Table("Master_Rig")]
    public class Rig: Entity<int>
    {

        [Column(Order = 10)]
        [StringLength(1024)]
        public string Description { get; set; }

        [Column(Order = 15)]
        [StringLength(50)]
        public string Code { get; set; }

        [Column(Order = 20)] 
        public int RigType { get; set; }

        [Column(Order = 25)]
        public int Status { get; set; }

        [NotMapped]
        public override DateTime CreatedDateTime { get; set; }

        [NotMapped]
        public override DateTime UpdatedDateTime { get; set; }

        [NotMapped] 
        public override string UpdatedBy { get; set; }

        [NotMapped]
        public override string CreatedBy { get; set; }
    }
}
