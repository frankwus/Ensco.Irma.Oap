using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Interfaces.Services.Oap.DPA
{
    public interface IOapDPAService
    {
        IEnumerable<Models.Domain.Oap.DPA> GetAllRigDPAs(int rigId);
    }
}
