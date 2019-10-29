using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap;

namespace Ensco.Irma.Services.Oap
{
    public class FindingTypeService : EntityService<IrmaOapDbContext, IFindingTypeRepository, FindingType, int>, IFindingTypeService
    {
        public FindingTypeService(IFindingTypeRepository findingTypeRepository) : base(findingTypeRepository)
        {

        }
    }
}
