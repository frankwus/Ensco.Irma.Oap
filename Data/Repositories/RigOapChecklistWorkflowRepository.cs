using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Services.Logging;
using System.Data.Entity;
using System.Linq;
using System;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Collections.Generic;

namespace Ensco.Irma.Data.Repositories
{
    public class RigOapChecklistWorkflowRepository : BaseRepository<IrmaOapDbContext, RigOapChecklistWorkflow, Guid>, IRigOapChecklistWorkflowRepository
    {
        public RigOapChecklistWorkflowRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext) context, log)
        {

        }

        protected override IQueryable<RigOapChecklistWorkflow> AllItems => Items.Include(ct => ct.RigOapCheckList).Include(ct => ct.RigOapCheckList.OapChecklist).Include(ct => ct.Workflow).Include(ct => ct.WorkflowState).Include(ct => ct.Transition);

        public RigOapChecklistWorkflow GetWorkflowByChecklist(Guid rigChecklistId)
        {
            return (from it in AllItems
                   where it.RigOapCheckList.Id == rigChecklistId
                   select it).FirstOrDefault(); 
        }
    }
}
