using Ensco.Irma.Models.Domain.IRMA;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Models.Domain.Oap
{
    public class OapAccountable : HistoricalEntityId<int>
    {        
        public int PositionId { get; set; }                
        public int ChecklistId { get; set; }
        public string Type { get; set; }
    }
}
