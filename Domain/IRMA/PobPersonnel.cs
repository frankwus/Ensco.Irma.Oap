using Ensco.Irma.Models.Domain.Security;
using System; 
using System.ComponentModel.DataAnnotations.Schema;  

namespace Ensco.Irma.Models.Domain.IRMA
{
    public class PobPersonnel : IrmaHistoricalEntityId<int>
    {

        [Column(Order = 5)] 
        public int PobPersonId { get; set; }
         
        [NotMapped]
        public Person PobPerson { get; set; }

        [Column(Order = 10)]  
        public int? TourId { get; set; }

        [NotMapped]
        public PobTour Tour { get; set; }

        [Column(Order = 15)] 
        public int? PobStatusId { get; set; }

        [Column(Order = 20)]
        public int? PersonnelTypeId { get; set; }

        public new DateTime? EndDateTime {get; set; }

        [Column(Order = 30)]
        public DateTime? EstimatedLeave { get; set; } 
         
    }
}
