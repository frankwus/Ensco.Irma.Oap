using System;
using System.ComponentModel.DataAnnotations.Schema;
using Ensco.Irma.Interfaces.Domain;

namespace Ensco.Irma.Models.Domain
{
    public class HistoricalEntityId<T> : EntityId<T>, IHistoricalEntityId<T>
       where T : struct
    {
        [Column(Order = 500, TypeName = "datetime2")]
        public virtual DateTime StartDateTime { get; set; }

        [Column(Order = 501, TypeName = "datetime2")]
        public virtual DateTime EndDateTime { get; set; }
    }
}
