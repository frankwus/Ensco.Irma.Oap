using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapSystemGroupService : EntityService<IrmaOapDbContext, IOapSystemGroupRepository, OapSystemGroup, int>, IOapSystemGroupService
    {
        public OapSystemGroupService(IOapSystemGroupRepository systemGroupRepository) : base(systemGroupRepository)
        {

        }
    }
}
