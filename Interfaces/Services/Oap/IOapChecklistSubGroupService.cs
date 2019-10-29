using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IOapChecklistSubGroupService : IHistoricalEntityService<OapChecklistSubGroup, int>
    {
        OapChecklistSubGroup GetBySubGroupName(int groupId, string name);
    }
}
