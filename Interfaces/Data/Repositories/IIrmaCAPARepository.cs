using Ensco.Irma.Models.Domain.IRMA;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IIrmaCAPARepository : IBaseIdRepository<IrmaCapa, int>
    {
        IEnumerable<IrmaCapa> GetCAPAsByIDs(IEnumerable<int> Ids);
        IrmaCapa GetCAPAByID(int Id);
        IEnumerable<IrmaCapa> GetCAPAsByChecklistId(Guid checklistId);
    }
}
