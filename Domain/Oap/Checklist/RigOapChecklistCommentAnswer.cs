using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class RigOapChecklistCommentAnswer : EntityId<Guid>
    {
        [Column(Order = 5)]
        [ForeignKey("RigOapChecklistComment")]
        public Guid RigOapChecklistCommentId { get; set; }

        [JsonIgnore]
        public RigOapChecklistComment RigOapChecklistComment { get; set; }

        [Column(Order = 10, TypeName = "NVARCHAR")]
        [StringLength(4000)]
        [Required]
        public string Comment { get; set; }
    }
}