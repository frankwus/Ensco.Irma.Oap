using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Models.Domain.Security;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class RigOapChecklistQuestionFinding: EntityId<Guid>
    {
        [Column(Order = 10)]
        [Required]
        public string Reason { get; set; }

        [Column(Order = 15)] 
        public int CriticalityId { get; set; }

        [Column(Order = 17)]
        [Required]
        public DateTime FindingDate { get; set; }

        [Column(Order = 20)]
        [ForeignKey("FindingType")]
        [Required]
        public int FindingTypeId { get; set; }
         
        public FindingType FindingType { get; set; }

        [Column(Order = 25)]
        [ForeignKey("FindingSubType")]
        [Required]
        public int FindingSubTypeId { get; set; }

        [JsonIgnore]
        public FindingSubType FindingSubType { get; set; }
 
        [Column(Order = 30)] 
        public int CapaId {get; set; }

        [Column(Order = 35)]
        [ForeignKey("RigOapChecklistQuestion")]
        public Guid RigOapChecklistQuestionId { get; set; }
          
        public RigOapChecklistQuestion RigOapChecklistQuestion { get; set; }

        [Column(Order = 40)]
        [StringLength(32)]
        public string Status { get; set; }

        [Column(Order = 45)]
        public bool IsRepeat { get; set; }

        [Column(Order = 50)]
        [Required]
        public int AssignedUserId { get; set; }

        [NotMapped]
        public Person AssignedUser { get; set; }

        [Column(Order = 55)]
        public string FileName { get; set; }

        [Column(Order = 60)]
        [Required]
        public int ReviewedByUserId { get; set; }

        [NotMapped]
        public Person ReviewedbyUser { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 65)]
        [Required]
        public int RigChecklistFindingInternalId { get; set; }
         
        [NotMapped]
        public byte[] FileStream { get; set; }
    }
}
