using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Workflow
{
    public abstract class WorkflowInstance : Entity<Guid>
    {
        public WorkflowInstance()
        {

        }

        public WorkflowInstance(string objectName, Guid objectId)
        {
            Inputs = new Dictionary<string, object>
            {
                { $"{objectName}", objectId }
            };
        }

        [Column(Order = 5)]
        [ForeignKey("Workflow")]
        public int? WorkflowId { get; set; }

        public Workflow Workflow { get; set; }

        [Column(Order = 10)]
        [ForeignKey("WorkflowState")]
        public int? WorkflowStateId { get; set; }

        public WorkflowState WorkflowState { get; set; }

        [Column(Order = 15)]
        [ForeignKey("Transition")]
        public virtual int WorkflowTransitionId { get; set; }

        public virtual WorkflowTransition Transition { get; set; }

        [Column(Order = 25)]
        public virtual Guid InstanceId {get; set;}

        [NotMapped]
        [JsonIgnore]
        public IDictionary<string, object> Inputs { get; set; }
    }
}
