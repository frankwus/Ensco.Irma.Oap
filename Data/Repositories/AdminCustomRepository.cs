using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.IRMA;
using Ensco.Irma.Models.Domain.Security;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    public class AdminCustomRepository : BaseRepository<IrmaDbContext, AdminCustom, int> , IAdminCustomRepository
    {
        public AdminCustomRepository(IIrmaDbContext context, ILog log) : base((IrmaDbContext)context, log)
        {

        }

        public override AdminCustom GetByName(string name)
        {
            var r = AllItems.FirstOrDefault(i => i.Name.Equals(name));

            return r;
        }
    }

    
}
