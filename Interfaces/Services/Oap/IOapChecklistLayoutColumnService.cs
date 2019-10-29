using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IOapChecklistLayoutColumnService : IEntityService<OapChecklistLayoutColumn, int>
    {
        IEnumerable<OapChecklistLayoutColumn> GetAll(int layoutId);
    }
}
