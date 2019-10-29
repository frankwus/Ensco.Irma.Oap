using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class RigOapChecklistComment : EntityId<Guid>
    {
        [Column(Order = 5)]
        [ForeignKey("RigOapChecklist")]
        public Guid RigOapChecklistId { get; set; }

        [JsonIgnore]
        public RigOapChecklist RigOapChecklist { get; set; }

        [Column(Order = 10)]
        [ForeignKey("OapChecklistComment")]
        public int? OapChecklistCommentId { get; set; }

        public OapChecklistComment OapChecklistComment { get; set; } 

        [Column(Order = 15, TypeName = "NVARCHAR")]
        [StringLength(4000)] 
        public string Comment { get; set; }
    }
}
