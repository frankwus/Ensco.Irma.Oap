using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap;

namespace Ensco.Irma.Services.Oap
{
    public class FindingSubTypeService : EntityService<IrmaOapDbContext, IFindingSubTypeRepository, FindingSubType, int>, IFindingSubTypeService
    {
        public FindingSubTypeService(IFindingSubTypeRepository findingSubTypeRepository) : base(findingSubTypeRepository)
        {

        }
    }
}
