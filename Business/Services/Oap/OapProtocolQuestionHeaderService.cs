using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapProtocolQuestionHeaderService : HistoricalEntityIdService<IrmaOapDbContext, IOapProtocolQuestionHeaderRepository, OapProtocolQuestionHeader, int>, IOapProtocolQuestionHeaderService
    {
        public OapProtocolQuestionHeaderService(IOapProtocolQuestionHeaderRepository repository) : base(repository)
        {

        }

        public OapProtocolQuestionHeader GetBySection(int questionId, string section)
        {
            return Repository.GetBySection(questionId, section);
        }
    }
}
