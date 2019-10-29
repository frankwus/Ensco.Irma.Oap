using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapChecklistLayoutService : EntityService<IrmaOapDbContext, IOapChecklistLayoutRepository, OapChecklistLayout, int>, IOapChecklistLayoutService
    {
        public OapChecklistLayoutService(IOapChecklistLayoutRepository repository) : base(repository)
        {

        }
    }
}
