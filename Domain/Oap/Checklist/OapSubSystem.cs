﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapSubSystem : Entity<int>
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
        [ForeignKey("OapSystem")]
        public int OapSystemId { get; set; }
         
        public OapSystem OapSystem { get; set; }
    }
}
