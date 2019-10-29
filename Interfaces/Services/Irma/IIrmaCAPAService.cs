using Ensco.Irma.Models.Domain.IRMA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Interfaces.Services.Irma
{
    public interface IIrmaCAPAService
    {
        IEnumerable<IrmaCapa> GetCAPAsByIds(IEnumerable<int> Ids);
        IrmaCapa GetCAPAById(int id);

        IEnumerable<IrmaCapa> GetCAPAsByChecklistId(Guid checklistId);

    }
}
