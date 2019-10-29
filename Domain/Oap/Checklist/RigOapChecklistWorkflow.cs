using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class RigOapChecklistWorkflow: Workflow.WorkflowInstance
    {
        public RigOapChecklistWorkflow(RigOapChecklist rigChecklist):base("RigOapChecklistId", rigChecklist.Id)
        {
            RigOapCheckList = rigChecklist;
        }

        public RigOapChecklistWorkflow():base()
        {

        }
       
        [Column(Order = 20)]
        [ForeignKey("RigOapCheckList")]
        public Guid RigOapCheckListId { get; set; }

        public RigOapChecklist RigOapCheckList { get; set; }
    }
}
