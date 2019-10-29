using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IOapHierarchyService : IHistoricalEntityService<OapHierarchy, int>
    {
        IEnumerable<OapHierarchy> GetAllParentHierarchy(DateTime startDate, DateTime endDate);
    }
}
