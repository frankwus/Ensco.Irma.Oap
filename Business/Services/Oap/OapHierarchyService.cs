using System;
using System.Collections.Generic;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapHierarchyService : HistoricalEntityService<IrmaOapDbContext, IOapHierarchyRepository, OapHierarchy, int>, IOapHierarchyService
    {
        public OapHierarchyService(IOapHierarchyRepository repository) : base(repository)
        {

        }

        public IEnumerable<OapHierarchy> GetAllParentHierarchy(DateTime startDate, DateTime endDate)
        {
            return Repository.GetAllParentHierarchy(startDate, endDate);
        }
    }
}
