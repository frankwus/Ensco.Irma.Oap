using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Workflow
{
    public abstract class WorkflowTransition : Entity<int>
    {
        protected WorkflowTransition(string name, string requiredPermission = null)
        { 
            Name = name;
            RequiredPermission = requiredPermission;
        }

        protected WorkflowTransition()
        {
        }

        [Column(Order = 4)]
        [ForeignKey("SourceWorkflowState")]
        public int SourceWorkflowStateId { get; set; }

        public virtual WorkflowState SourceWorkflowState { get; set; }

        [Column(Order = 5)]
        [ForeignKey("ToWorkflowState")]
        public int? ToWorkflowStateId { get; set; }

        public virtual WorkflowState ToWorkflowState { get; set; }

        [Column(Order = 6)]
        [StringLength(64)]
        public string RequiredPermission { get; set; }
 
    }

}






