using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Workflow
{
    public class WorkflowActivity : Entity<int>
    {
        [Column(Order = 3, TypeName = "NVARCHAR")]
        [StringLength(1024)]
        public string Description { get; set; }

        [Column(Order = 4)]
        [ForeignKey("WorkflowState")]
        public virtual int? WorkStateId { get; set; }

        public virtual WorkflowState WorkflowState { get; set; }

        [Column(Order = 5)]
        [ForeignKey("WorkflowTransition")]
        public virtual int? WorkflowTransitionId { get; set; }

        public virtual WorkflowTransition WorkflowTransition { get; set; }

        [Column(Order = 6, TypeName = "NVARCHAR")]
        [StringLength(5)]
        public virtual string StateType { get; set; }

        [Column(Order = 7, TypeName = "NVARCHAR")]
        [StringLength(5)]
        public virtual string TransitionType { get; set; }
    }
}
