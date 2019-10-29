using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface IOapProtocolQuestionHeaderService : IHistoricalEntityIdService<OapProtocolQuestionHeader, int>
    {
        OapProtocolQuestionHeader GetBySection(int questionId, string section);
    }
}
