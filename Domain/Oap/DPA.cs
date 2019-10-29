using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Models.Domain.Oap
{
    public class DPA : EntityId<int>
    {
        [Column(Order = 10)]
        public int UserId { get; set; }

        [Column(Order = 20)]        
        public int AssignedRigId { get; set; }
    }
}
