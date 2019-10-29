using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Workflow
{
    public class WorkflowInstanceActivity : Entity<Guid>
    {
        [ForeignKey("WorkflowInstance")]
        [Column(Order = 4)]
        public Guid WorkflowInstanceId { get; set; }

        public WorkflowInstance WorkflowInstance { get; set; }

        [ForeignKey("WorkflowActivity")]
        [Column(Order = 5)]
        public int WorkflowActivityId { get; set; }

        public WorkflowActivity WorkflowActivity { get; set; }

        [Column(Order = 6, TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string RequestVerb { get; set; }

        [Column(Order = 7, TypeName = "NVARCHAR")]
        [StringLength(512)]
        public string RequiredPermission { get; set; }

        [Column(Order = 8)] 
        public bool PromptForPeople { get; set; }

        [Column(Order = 98)]
        public bool PromptFilter { get; set; }

        [Column(Order = 10, TypeName = "NVARCHAR")]
        [StringLength(32)]
        public string RequestType { get; set; }

        [Column(Order = 11, TypeName = "NVARCHAR")]
        [StringLength(512)]
        public string RequestJson { get; set; }

    }
}
