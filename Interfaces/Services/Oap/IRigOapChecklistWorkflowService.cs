using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IRigOapChecklistWorkflowService : IEntityService<RigOapChecklistWorkflow, Guid>
    {
        RigOapChecklistWorkflow GetWorkflowByChecklist(Guid rigChecklistId);

        void StartChecklistWorkFlow(RigOapChecklist checklist);
        void SignWorkFlow(RigOapChecklist checklist, int userId, int order, string comment);
        void RejectWorkFlow(RigOapChecklist checklist, int userId, int order, string comment);
        void Review(RigOapChecklist checklist, int userId, int order, string comment);
        void Cancel(RigOapChecklist checklist, int userId, int order, string comment);
        void UpdateRigChecklistsStatus(IEnumerable<RigOapChecklist> rList);
    }
}
