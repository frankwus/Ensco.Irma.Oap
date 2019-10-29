using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapFrequencyType : HistoricalEntity<int>
    {
        [Column(Order = 5)]
        [StringLength(1024)]
        public string Description { get; set; }
    }
}
