using System.Collections.Generic;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{

    public class OapChecklistLayoutColumnService : EntityService<IrmaOapDbContext, IOapChecklistLayoutColumnRepository, OapChecklistLayoutColumn, int>, IOapChecklistLayoutColumnService
    {
        public OapChecklistLayoutColumnService(IOapChecklistLayoutColumnRepository repository) : base(repository)
        {

        }

        public IEnumerable<OapChecklistLayoutColumn> GetAll(int layoutId)
        {
            return Repository.GetAll(layoutId);
        }
    }
}
