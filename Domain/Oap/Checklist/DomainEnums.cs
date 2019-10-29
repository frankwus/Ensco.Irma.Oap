using System.ComponentModel;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    [DefaultValue(None)]
    public enum VerifierRole
    {
        None,
        Assessor,
        Reviewer,
        OIM,
        RigManager,
        Master
    }


    [DefaultValue(Open)]
    public enum ChecklistStatus
    {
        Open,
        Pending,
        Completed,
        Canceled
    }

    [DefaultValue(Pending)]
    public enum WorkflowStatus
    { 
        Pending,
        Completed,
        Rejected,
        Canceled
    }

}
