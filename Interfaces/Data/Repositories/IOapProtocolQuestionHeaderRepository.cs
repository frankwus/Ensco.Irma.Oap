using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Interfaces.Data.Repositories
{
    public interface IOapProtocolQuestionHeaderRepository : IHistoricalBaseIdRepository<OapProtocolQuestionHeader, int>
    {
        OapProtocolQuestionHeader GetBySection(int questionId, string section);
    }
}
