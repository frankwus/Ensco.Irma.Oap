using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Data.Repositories
{
    public class OapHierarchyRepository : HistoricalBaseRepository<IrmaOapDbContext, OapHierarchy, int> , IOapHierarchyRepository
    {
        public OapHierarchyRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        protected override IQueryable<OapHierarchy> AllItems => Items.Include(p => p.ParentHierarchy).Include(p => p.ChecklistLayout).Include(p => p.ChildrenHierarchies);

        public IEnumerable<OapHierarchy> GetAllParentHierarchy(DateTime startDate, DateTime endDate)
        {
            return (from it in AllItems
                    where it.StartDateTime <= startDate && it.EndDateTime >= endDate && it.ParentHierarchyId == null
                    select it).ToList();
        }
    }
}
