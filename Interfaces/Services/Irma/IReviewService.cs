using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Models.Domain.IRMA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Interfaces.Services.Irma
{
    public interface IReviewService : IEntityIdService<IrmaReview, int>
    {
    }
}
