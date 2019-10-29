using Ensco.Irma.Data.Context;
using Ensco.Irma.Data.Repositories;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Services.Oap
{
    public class OapAccountableService : HistoricalEntityIdService<IrmaOapDbContext, IOapAccountableRepository, OapAccountable, int>, IOapAccountableService
    {
        public OapAccountableService(IOapAccountableRepository repository) : base(repository)
        {
        }

        public IEnumerable<OapAccountable> GetAllByPositionIds(int[] ids)
        {
            return Repository.GetAllByPositionIds(ids);
        }
    }
}
