using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Data.Repositories
{
    public class OapDPARepository : BaseIdRepository<IrmaOapDbContext, DPA, int>, IOapDPARepository
    {
        public OapDPARepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {
        }

        public IEnumerable<DPA> GetAllRigDPAs(int rigId)
        {
            return AllItems.Where(d => d.AssignedRigId == rigId);
        }

    }
}
