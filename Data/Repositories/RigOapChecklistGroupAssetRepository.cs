
using System;

namespace Ensco.Irma.Data.Repositories
{
    using Ensco.Irma.Data.Context;
    using Ensco.Irma.Interfaces.Data.Repositories;
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;

    public class RigOapChecklistGroupAssetRepository : BaseIdRepository<IrmaOapDbContext, RigOapChecklistGroupAsset, Guid>, IRigOapChecklistGroupAssetRepository
    {
        public RigOapChecklistGroupAssetRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext) context, log)
        {

        }
    }
}
