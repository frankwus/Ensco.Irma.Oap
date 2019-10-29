using Ensco.Irma.Models.Domain.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapChecklistLayout: Entity<int>
    {
        [Column(Order = 5)]
        [StringLength(1024)]
        [Required]
        public string Description { get; set; }

        [Column(Order = 10)]
        [InverseProperty("ChecklistLayout")]
        public ICollection<OapChecklistLayoutColumn> Columns { get; set; } 
    }
}
