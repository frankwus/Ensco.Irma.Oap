using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapChecklistGroupService : HistoricalEntityService<IrmaOapDbContext, IOapChecklistGroupRepository, OapChecklistGroup, int>, IOapChecklistGroupService
    {
        public OapChecklistGroupService(IOapChecklistGroupRepository repository) : base(repository)
        {

        }
    }
}
