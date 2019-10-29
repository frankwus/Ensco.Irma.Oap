using Ensco.Irma.Models.Domain.Security;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class RigOapChecklistVerifier : Assignee<Guid>
    {
        public RigOapChecklistVerifier() {}

        public RigOapChecklistVerifier(int userId, string role, int order)
        {
            Id = new Guid();
            UserId = userId;
            Role = role;
            Order = order;
        }

        [Column(Order = 5)]
        [ForeignKey("RigOapChecklist")]
        public Guid? RigOapChecklistId { get; set; }

        [JsonIgnore]
        public RigOapChecklist RigOapChecklist { get; set; }

        [Column(Order = 10)]
        [StringLength(1024)]
        public string Comment { get; set; }

        [Column(Order = 15)] 
        public DateTime? SignedOn { get; set; }

        [Column(Order = 20)]
        public int Order { get; set; }

        /// <summary>
        /// Stores the Approval status - Pending/Completed/
        /// </summary>
        [Column(Order = 25)]
        public string Status { get; set; }

        [Column(Order = 30)]
        public bool isReviewer { get; set; }        
    }
}
