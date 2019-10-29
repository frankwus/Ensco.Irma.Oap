using Ensco.Irma.Models.Domain.Oap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IOapDPARepository : IBaseIdRepository<DPA, int>
    {
        IEnumerable<DPA> GetAllRigDPAs(int rigId);
    }
}
