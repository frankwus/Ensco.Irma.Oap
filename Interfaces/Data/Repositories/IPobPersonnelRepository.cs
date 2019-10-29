using Ensco.Irma.Models.Domain.IRMA;
using System.Collections.Generic;

namespace Ensco.Irma.Interfaces.Data.Repositories.Irma
{
    public interface IPobPersonnelRepository : IHistoricalBaseIdRepository<PobPersonnel, int>
    {
        IEnumerable<PobPersonnel> GetReviewers(string rigId, int pobStatusId, IList<int> positions);

        int? GetTourId(int userId);

        PobPersonnel GetPobPersonnel(int userId);
    }
}
