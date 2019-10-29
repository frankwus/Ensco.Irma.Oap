using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IOapChecklistLayoutColumnRepository: IBaseRepository<OapChecklistLayoutColumn, int>
    {
        IEnumerable<OapChecklistLayoutColumn> GetAll(int layoutId);
    }
}
