using Ensco.Irma.Interfaces.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ensco.Irma.Models.Domain.Workflow
{
    public class WorkflowResult : Entity<int>
    {
        public WorkflowResult()
        {
            NewState = new WorkflowState();
            Name = Guid.NewGuid().ToString();
        }

        [StringLength(1024)]
        public string Context { get; set; }

        public virtual WorkflowState NewState { get; set; }
        public Exception Error { get; set; }        
    }
}
