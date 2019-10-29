using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap
{
    public class FindingType : Entity<int>
    {
        [Column(Order = 10)] 
        public string Description { get; set; }

        [Column(Order = 20)]
        [InverseProperty("FindingType")]
        public virtual ICollection<FindingSubType> SubTypes { get; set; }
    }
}