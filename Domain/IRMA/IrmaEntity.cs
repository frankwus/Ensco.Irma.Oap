using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Models.Domain.IRMA
{
    public abstract class IrmaEntity<T>: Entity<T>
         where T : struct
    {
        [NotMapped]
        public override DateTime CreatedDateTime { get; set; }

        [NotMapped]
        public override DateTime UpdatedDateTime { get; set; }

        [NotMapped]
        public override string UpdatedBy { get; set; }

        [NotMapped]
        public override string CreatedBy { get; set; }

        [NotMapped]
        public override string SiteId { get; set; }

    }
}
