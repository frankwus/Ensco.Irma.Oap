using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapChecklistCommentService : HistoricalEntityIdService<IrmaOapDbContext, IOapChecklistCommentRepository, OapChecklistComment, int>, IOapChecklistCommentService
    {
        public OapChecklistCommentService(IOapChecklistCommentRepository repository) : base(repository)
        {

        }
    }
}
