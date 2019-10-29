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
    public class OapChecklistQuestionTagMap : EntityId<int>
    {
        [Column(Order = 5)]
        [ForeignKey("OapChecklistQuestion")]
        public int OapChecklistQuestionId { get; set; }

        public OapChecklistQuestion OapChecklistQuestion { get; set; }

        [Column(Order = 15)]
        [ForeignKey("OapChecklistQuestionTag")]
        public int OapChecklistQuestionTagId { get; set; }

        public OapChecklistQuestionTag OapChecklistQuestionTag { get; set; }

    }
}
