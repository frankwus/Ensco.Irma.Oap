using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapChecklistReviewerService : HistoricalEntityIdService<IrmaOapDbContext, IOapChecklistReviewerRepository, OapChecklistReviewer, int>, IOapChecklistReviewerService
    {
        public OapChecklistReviewerService(IOapChecklistReviewerRepository repository) : base(repository)
        {

        }
    }
}
