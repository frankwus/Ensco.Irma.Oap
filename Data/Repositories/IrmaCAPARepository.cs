using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.IRMA;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Data.Repositories
{
    public class IrmaCAPARepository : BaseIdRepository<IrmaDbContext, IrmaCapa, int>, IIrmaCAPARepository
    {
        IIrmaOapDbContext oapDbContext;
        public IrmaCAPARepository(IIrmaDbContext context, ILog log, IIrmaOapDbContext oapContext) : base((IrmaDbContext)context, log)
        {
            oapDbContext = oapContext;
        }        

        public IrmaCapa GetCAPAByID(int Id)
        {
            return (from capa in AllItems
                   where capa.Id == Id
                   select capa).FirstOrDefault();
        }

        public IEnumerable<IrmaCapa> GetCAPAsByIDs(IEnumerable<int> Ids)
        {
            return from capa in AllItems
                   where Ids.Any(id => id == capa.Id)
                   select capa;
        }

        public IEnumerable<IrmaCapa> GetCAPAsByChecklistId(Guid checklistId)
        {
            // get all findings for checklist
            return from capa in AllItems
                   where capa.SourceUrl == "/oap/Generic/List/"+checklistId
                   select capa;

            //RigOapChecklist checklist = oapDbContext.RigOapChecklists.Where(c => c.Id == checklistId).FirstOrDefault();
            //if (checklist == null)
            //    return null;

            //IEnumerable<RigOapChecklistQuestion> questions = oapDbContext.RigOapChecklistQuestions.Where(q => q.RigOapChecklistId == checklist.Id);
            //IEnumerable<RigOapChecklistQuestionFinding> findings =
            //    oapDbContext.RigOapChecklistQuestionFindings.Where(f => questions.Any(q => q.Id == f.RigOapChecklistQuestionId));

            //var capaIds = (from f in findings
            //               where f.CapaId != 0
            //               select f.CapaId).AsEnumerable();

            //return GetCAPAsByIDs(capaIds);

        }

    }
}
