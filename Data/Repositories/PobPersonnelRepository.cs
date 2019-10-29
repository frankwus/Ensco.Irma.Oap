using System.Collections.Generic;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories.Irma;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.IRMA;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    public class PobPersonnelRepository : HistoricalBaseIdRepository<IrmaDbContext, PobPersonnel, int>, IPobPersonnelRepository
    {
        public PobPersonnelRepository(IIrmaDbContext context, ILog log) : base((IrmaDbContext)context, log)
        {

        }

        public IEnumerable<PobPersonnel> GetReviewers(string rigId, int pobStatusId, IList<int> positions)
        {
            var reviewers = (from pp in Context.PobPeople
                             from p in Context.People
                             where pp.PobPersonId == p.Id
                                 && pp.PobStatusId == pobStatusId
                                 && p.PositionId != null && positions.Contains(p.PositionId.Value)
                                 && p.RigId.ToString() == rigId
                             select new { pp, p }).ToList();

            reviewers.ForEach(np =>
            {
                np.pp.PobPerson = np.p;
            });

            return reviewers.Select(np => np.pp).ToList();
        }


        public int? GetTourId(int userId)
        {
            var tour = Context.PobPeople.Where(c => c.PobPersonId == userId && c.PobStatusId == 1 && c.StartDateTime != null && c.EndDateTime == null)?.FirstOrDefault();
            return tour?.TourId;
        }

        public PobPersonnel GetPobPersonnel(int userId)
        {
            var tour = Context.PobPeople.Where(c => c.PobPersonId == userId && c.PobStatusId == 1)?.FirstOrDefault();
            return tour;
        }

    }
}
