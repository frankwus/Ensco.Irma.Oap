using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services;
using Ensco.Irma.Interfaces.Services.Irma;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.IRMA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Services.Irma
{
    public class ReviewService : EntityIdService<IrmaDbContext, IIrmaReviewRepository, IrmaReview, int>, IReviewService
    {
        public ReviewService(IIrmaReviewRepository repository, ILog log) : base(repository, log)
        {
        }
    }
}
