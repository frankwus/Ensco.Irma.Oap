using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapCheckListQuestionRelatedQuestionMap: EntityId<int>
    {
        [Column(Order = 5)]
        [ForeignKey("OapChecklistQuestion")]
        public int OapChecklistQuestionId { get; set; }

        public OapChecklistQuestion OapChecklistQuestion { get; set; }

        [Column(Order =10)]
        [ForeignKey("OapChecklistRelatedQuestion")]
        public int? OapChecklistRelatedQuestionId { get; set; }

        public OapChecklistQuestion OapChecklistRelatedQuestion { get; set; }
    }
}
