using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapChecklistQuestionTag : EntityId<int>
    {
        [Column(Order = 5)] 
        [StringLength(128)]
        public string Tag { get; set; }
        
    }
}
