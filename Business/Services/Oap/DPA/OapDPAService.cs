using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap.DPA;
using Ensco.Irma.Models.Domain.Oap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Services.Oap.DPA
{
    public class OapDPAService : IOapDPAService
    {
        private readonly IOapDPARepository repository;

        public OapDPAService(IOapDPARepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Models.Domain.Oap.DPA> GetAllRigDPAs(int rigId)
        {
            return repository.GetAllRigDPAs(rigId);
        }
    }
}
