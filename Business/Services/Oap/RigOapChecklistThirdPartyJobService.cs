using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;

namespace Ensco.Irma.Services.Oap
{
    public class RigOapChecklistThirdPartyJobService : EntityIdService<IrmaOapDbContext, IRigOapChecklistThirdPartyJobRepository, RigOapChecklistThirdPartyJob, Guid>, IRigOapChecklistThirdPartyJobService
    {

        public RigOapChecklistThirdPartyJobService(IRigOapChecklistThirdPartyJobRepository rigOapChecklistThirdPartyJobRepository) : base(rigOapChecklistThirdPartyJobRepository)
        {
        }
    }
}
