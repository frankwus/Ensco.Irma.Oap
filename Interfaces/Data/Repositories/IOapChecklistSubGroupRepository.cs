using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IOapChecklistSubGroupRepository : IHistoricalBaseRepository<OapChecklistSubGroup, int>
    {
        OapChecklistSubGroup GetBySubGroupName(int groupId, string name);
    }
}
