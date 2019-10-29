using Ensco.Irma.Models.Domain.Attributes;
using Ensco.Irma.Models.Domain.IRMA; 
using Ensco.Irma.Models.Domain.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class RigOapChecklist : EntityId<Guid>
    {

        //This is to have unique Id for display instead of guid.
        //Used for displaying
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 4)] 
        [Required]
        public int RigChecklistUniqueId { get; set; }

        [Column(Order = 5)]
        [StringLength(256)]
        [Required]
        public string Title { get; set; }

        [Column(Order = 10)]
        [StringLength(1024)]
        public string Description { get; set; }

        [Column(Order = 15, TypeName = "datetime2")]
        public DateTime ChecklistDateTime { get; set; }

        [Column(Order = 20)] 
        public int? JobId { get; set; }

        [Column(Order = 25)] 
        [Required]
        public int LocationId { get; set; }

        // This column is required on the db table but not here so it can get the default value and not fail in the model validation
        [Column(Order = 30)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[SqlDefaultValue("dbo.fn_GetRigId()")]   
        [Required]
        public int RigId = 63;//{ get; set; } 

        [Column(Order = 35)]
        [ForeignKey("OapChecklist")]
        public int OapchecklistId { get; set; }
         
        public OapChecklist OapChecklist { get; set; }

        [Column(Order = 40)]  
        public int OwnerId { get; set; }
         
        [Column(Order = 45)]
        [InverseProperty("RigOapChecklist")]
        public virtual ICollection<RigOapChecklistAssessor> Assessors { get; set; }

        [Column(Order = 50)]
        [InverseProperty("RigOapChecklist")]
        public virtual ICollection<RigOapChecklistVerifier> VerifiedBy { get; set; } 

        [Column(Order = 60)]
        [InverseProperty("RigOapChecklist")]
        public virtual ICollection<RigOapChecklistComment> Comments { get; set; }

        [Column(Order = 65)]
        [InverseProperty("RigOapChecklist")]
        public virtual ICollection<RigOapChecklistQuestion> Questions { get; set; }        

        [Column(Order = 70)]
        [StringLength(16)]
        public string Status { get; set; }

        [Column(Order = 80)] 
        public bool IsAutoScheduled { get; set; }


        [Column(Order = 85)]
        [StringLength(128)]
        public string Reason { get; set; }


        [Column(Order = 86, TypeName = "datetime2")]
        public DateTime ChecklistDateTimeCompleted { get; set; }

        [Column(Order = 87)]
        public string ISMCertified { get; set; }


        [Column(Order = 95)]
        [InverseProperty("RigOapChecklist")]
        public virtual ICollection<RigOapChecklistGroupAsset> Assets { get; set; }


        [Column(Order = 100)]
        [InverseProperty("RigOapChecklist")]
        public virtual ICollection<RigOapChecklistWorkInstruction> WorkInstructions { get; set; }

        [Column(Order = 105)]
        [InverseProperty("RigOapChecklist")]
        public virtual ICollection<RigOapChecklistThirdPartyJob> ThirdPartyJobs { get; set; }

        [NotMapped]
        public Person Owner { get; set; }

        public RigOapChecklist()
        {
            Assessors = new List<RigOapChecklistAssessor>();
            VerifiedBy = new List<RigOapChecklistVerifier>();
        }

        public void AddVerifier(int userId, string role, int order)
        {
            VerifiedBy.Add(new RigOapChecklistVerifier(userId, role, order));
        }
    }
}
