using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class RigOapChecklistQuestionComment : EntityId<Guid>
    {
        [Column(Order = 5)]
        [ForeignKey("RigOapChecklistQuestion")]
        public Guid RigOapChecklistQuestionId { get; set; }

        [JsonIgnore]
        public RigOapChecklistQuestion RigOapChecklistQuestion { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 10)]
        public int? OapChecklistQuestionCommentId { get; set; }

        [Column(Order = 15)]
        [Required]
        public DateTime CommentDate { get; set; }

        [Column(Order = 20, TypeName = "NVARCHAR")]
        [StringLength(2048)]
        [Required]
        public string Comment { get; set; }

        [Column(Order = 25)]
        [Required]
        public int CommentBy { get; set; }
    }
}
