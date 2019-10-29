using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Irma;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.IRMA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Services.Irma
{
    public class IrmaCAPAService : EntityIdService<IrmaDbContext, IIrmaCAPARepository, IrmaCapa, int>, IIrmaCAPAService
    {
        public IrmaCAPAService(IIrmaCAPARepository repository, ILog log) : base(repository, log)
        {
        }

        public IrmaCapa GetCAPAById(int id)
        {
            return Repository.GetCAPAByID(id);
        }        

        public IEnumerable<IrmaCapa> GetCAPAsByIds(IEnumerable<int> Ids)
        {
            return Repository.GetCAPAsByIDs(Ids);
        }

        public IEnumerable<IrmaCapa> GetCAPAsByChecklistId(Guid checklistId)
        {
            return Repository.GetCAPAsByChecklistId(checklistId);
        }
    }
}
