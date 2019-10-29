using System;
using System.ComponentModel.DataAnnotations.Schema;
using Ensco.Irma.Interfaces.Domain;

namespace Ensco.Irma.Models.Domain
{
    public class HistoricalEntity<T> : Entity<T>, IHistoricalEntity<T>
        where T: struct
    {
        [Column(Order=500, TypeName = "datetime2")]
        public DateTime StartDateTime { get; set; }

        [Column(Order = 501, TypeName = "datetime2")]
        public DateTime EndDateTime { get; set; }
    }
}
