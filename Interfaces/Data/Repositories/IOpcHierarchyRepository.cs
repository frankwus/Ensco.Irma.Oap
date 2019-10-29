using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IOapHierarchyRepository:IHistoricalBaseRepository<OapHierarchy, int>
    {
        IEnumerable<OapHierarchy> GetAllParentHierarchy(DateTime startDate, DateTime endDate);
    }
}
