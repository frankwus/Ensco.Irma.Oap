using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    using Newtonsoft.Json;

    public class RigOapChecklistWorkInstruction : EntityId<Guid>
    {
        [Column(Order = 5)]
        [ForeignKey("RigOapChecklist")]
        public Guid RigOapChecklistId { get; set; }

        [JsonIgnore]
        public RigOapChecklist RigOapChecklist { get; set; }

        [Column(Order = 10)]
        [ForeignKey("WorkInstruction")]
        public int WorkInstructionId { get; set; }

        public OapChecklistWorkInstruction WorkInstruction { get; set; }

        [Column(Order = 15)]
        public string Comment { get; set; }


        [Column(Order = 20)]
        public string Value { get; set; }
    }
}
