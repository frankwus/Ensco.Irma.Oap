using Ensco.Irma.Models.Domain.Oap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IOapAccountableService : IEntityIdService<OapAccountable, int>
    {
        IEnumerable<OapAccountable> GetAllByPositionIds(int[] ids);
    }
}
