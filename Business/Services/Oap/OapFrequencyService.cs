using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapFrequencyService : HistoricalEntityService<IrmaOapDbContext, IOapFrequencyRepository, OapFrequency, int> , IOapFrequencyService
    {
        public OapFrequencyService(IOapFrequencyRepository repository) : base(repository)
        {

        }
    }
}
