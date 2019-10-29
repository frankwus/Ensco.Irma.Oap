using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.IRMA
{
    public abstract class IrmaHistoricalEntityId<T> : HistoricalEntityId<T>
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
