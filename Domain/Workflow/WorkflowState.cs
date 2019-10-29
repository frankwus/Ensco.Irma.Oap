using Ensco.Irma.Models.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Workflow
{
    public class WorkflowState : Entity<int>
    {
        public WorkflowState(string name)
            : this()
        {
            Name = name;
        }
        
        public WorkflowState()
        {
            Transitions = new Collection<WorkflowTransition>();
        }

        [Column(Order = 3)]
        [StringLength(1024)]
        public string Context { get; set; }

        [JsonIgnore]
        [InverseProperty("SourceWorkflowState")]
        public virtual ICollection<WorkflowTransition> Transitions { get; set; }
        
    }
}
