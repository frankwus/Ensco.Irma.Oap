using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Models.Domain.Workflow;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IRigOapChecklistWorkflowRepository : IBaseRepository<RigOapChecklistWorkflow, Guid>
    {
        RigOapChecklistWorkflow GetWorkflowByChecklist(Guid rigChecklistId);
    }
}
