using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Models.Domain.IRMA
{
    [Table("IRMACAPA")]
    public class IrmaCapa : IrmaEntityId<int>
    {

        [Column(Order = 10)]
        public string  ActionRequired { get; set; }

        [Column(Order = 20)]
        public string AssignedTo { get; set; }

        [Column(Order = 30)]
        public DateTime? DueDate { get; set; }

        [Column(Order = 40)]
        public string Status { get; set; }

        [Column(Order = 50)]
        public DateTime? DateCompleted { get; set; }

        [Column(Order = 55)]
        public string Source { get; set; }
        [Column(Order = 60)]
        public string SourceId { get; set; }
        [Column(Order = 65)]
        public string SourceUrl { get; set; }
    }
}
