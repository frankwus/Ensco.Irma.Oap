using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.IRMA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Data.Repositories
{
    public class IrmaReviewRepository : BaseIdRepository<IrmaDbContext, IrmaReview, int>, IIrmaReviewRepository
    {
        public IrmaReviewRepository(IIrmaDbContext context, ILog log) : base((IrmaDbContext)context, log)
        {
        }
    }
}
