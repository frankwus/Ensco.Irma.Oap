using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class RigOapChecklistQuestionNoAnswerComment : EntityId<Guid>
    {   
        public int OapChecklistQuestionId { get; set; }
        public int OapChecklistId { get; set; }
        [NotMapped]
        public OapChecklistQuestion OapChecklistQuestion { get; set; }

        /// <summary>
        /// RigOapChecklist that started the No Answer lifecycle
        /// </summary>
        [Column(Order = 10)]
        public Nullable<Guid> SourceRigOapChecklistId { get; set; }


        /// <summary>
        /// RigOapChecklist that ended the No Answer lifecycle
        /// </summary>
        [Column(Order = 12)]
        public Nullable<Guid> ClosureRigOapChecklistId { get; set; }

        [Column(Order = 15, TypeName = "NVARCHAR")]
        [StringLength(2048)]
        public string Comment { get; set; }

        [Column(Order = 20)]
        [Required]
        public int StartCommentBy { get; set; }

        [Column(Order = 22, TypeName = "datetime2")]
        public DateTime StartDateTime { get; set; }

        [Column(Order = 24, TypeName = "datetime2")]
        public Nullable<DateTime> EndDateTime { get; set; }

        [Column(Order = 25)]
        public int? EndCommentBy { get; set; }

        [Column(Order = 30, TypeName = "NVARCHAR")]
        [StringLength(2048)] 
        public string Correction { get; set; }

        [Column(Order = 35)]
        public bool? IsStopWorkAuthorityExercised { get; set; }

        [Column(Order = 40)]
        public bool? WasAbletoCorrectImmediately { get; set; }

        public ICollection<RigOapChecklistQuestionNoAnswerReview> Reviews { get; set; }

        [NotMapped]
        public string Status => (EndDateTime != null || EndDateTime == DateTime.MinValue) ? "Closed" : "Open";

    }
}
