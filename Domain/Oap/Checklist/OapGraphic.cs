using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapGraphic : HistoricalEntity<int>
    {
        [Column(Order = 5)]
        [StringLength(1024)]
        public string Description { get; set; }

        [NotMapped]
        //[Column(Order = 10)] 
        public string ImageLocation { get; set; }

        //[NotMapped]
        [Column(Order = 10)]
        public byte[] Image { get; set; }
    }
}
