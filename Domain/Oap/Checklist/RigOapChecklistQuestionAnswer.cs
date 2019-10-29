using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class RigOapChecklistQuestionAnswer : EntityId<Guid>
    {
        [Column(Order = 5)]
        [ForeignKey("RigOapChecklistQuestion")]
        public Guid RigOapChecklistQuestionId { get; set; }

        [JsonIgnore]
        public RigOapChecklistQuestion RigOapChecklistQuestion { get; set; }

        [Column(Order = 10)]
        public int Ordinal { get; set; }

        [Column(Order = 15)] 
        public string Value { get; set; }

        [NotMapped]
        public bool IsLocked { get; set; }
    }
}