using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class RigOapChecklistQuestion : EntityId<Guid>
    {
        [Column(Order = 5)]
        [ForeignKey("RigOapChecklist")]
        public virtual Guid RigOapChecklistId { get; set; }

        [JsonIgnore]
        public virtual RigOapChecklist RigOapChecklist { get; set; }

        [Column(Order = 10)]
        [ForeignKey("OapChecklistQuestion")]
        public virtual int? OapChecklistQuestionId { get; set; }

        [Column(Order = 12)]
        public virtual string Comment { get; set; }

        public virtual OapChecklistQuestion OapChecklistQuestion { get; set; }
        
        [Column(Order = 15)]
        [InverseProperty("RigOapChecklistQuestion")]
        public virtual ICollection<RigOapChecklistQuestionAnswer> Answers { get; set; }

        [Column(Order = 20)]
        [InverseProperty("RigOapChecklistQuestion")]
        public virtual ICollection<RigOapChecklistQuestionComment> Comments { get; set; }

        [JsonIgnore]
        [Column(Order = 25)]
        [InverseProperty("RigOapChecklistQuestion")]
        public virtual ICollection<RigOapChecklistQuestionFinding> Findings { get; set; }
        
        [Column(Order = 40)]
        public int NoValue { get; set; }

    }
}
