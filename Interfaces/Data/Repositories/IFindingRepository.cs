using Ensco.Irma.Models.Domain.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IRigOapFindingRepository : IBaseIdRepository<RigOapChecklistFinding, Guid>
    {
    }
}