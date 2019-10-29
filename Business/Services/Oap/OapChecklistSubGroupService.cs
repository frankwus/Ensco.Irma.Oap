using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapChecklistSubGroupService : HistoricalEntityService<IrmaOapDbContext, IOapChecklistSubGroupRepository, OapChecklistSubGroup, int>, IOapChecklistSubGroupService
    {
        public OapChecklistSubGroupService(IOapChecklistSubGroupRepository repository) : base(repository)
        {

        }

        public OapChecklistSubGroup GetBySubGroupName(int groupId, string name)
        {
            return Repository.GetBySubGroupName(groupId,name);
        }
    }
}
