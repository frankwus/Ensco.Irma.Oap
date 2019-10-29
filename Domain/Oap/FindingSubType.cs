using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap
{
    public class FindingSubType:Entity<int>
    {
        [Column(Order = 10)]
        public string Description { get; set; }

        [Column(Order = 15)]
        [ForeignKey("FindingType")] 
        public int? FindingTypeId { get; set; }

        [JsonIgnore]
        public FindingType FindingType { get; set; }

    }
}