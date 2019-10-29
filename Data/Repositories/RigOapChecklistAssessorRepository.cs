using Ensco.Irma.Data.Context;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Data.Repositories;
using System;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Interfaces.Data.Repositories;

namespace Ensco.Irma.Data.Repositories
{
    public class RigOapChecklistAssessorRepository : BaseIdRepository<IrmaOapDbContext, RigOapChecklistAssessor, Guid>, IRigOapChecklistAssessorRepository
    {
        public RigOapChecklistAssessorRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {
        }
    }
}
