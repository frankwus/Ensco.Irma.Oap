using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    using Ensco.Irma.Models.Domain.Security;
    using Newtonsoft.Json;

    public class RigOapChecklistAssessor : Assignee<Guid>
    {
        [Column(Order = 5)]
        [ForeignKey("RigOapChecklist")]
        public Guid? RigOapChecklistId { get; set; }

        [Column(Order = 10)] 
        public bool IsLead { get; set; }

        [JsonIgnore]
        public RigOapChecklist RigOapChecklist { get; set; }
    }
}
