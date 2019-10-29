using Ensco.Irma.Models.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.IRMA
{
    public class Criticality : IrmaEntity<int>
    {  
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
