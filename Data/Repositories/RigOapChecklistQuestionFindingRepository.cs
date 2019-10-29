using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    public class RigOapChecklistQuestionFindingRepository : BaseIdRepository<IrmaOapDbContext, RigOapChecklistQuestionFinding, Guid>, IRigOapChecklistQuestionFindingRepository
    {
        public RigOapChecklistQuestionFindingRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        public override RigOapChecklistQuestionFinding Get(Guid id)
        {
            return (from f in AllItems.Include(f => f.RigOapChecklistQuestion.OapChecklistQuestion)
                              .Include(f => f.RigOapChecklistQuestion.RigOapChecklist)
                    where f.Id == id
                    select f).FirstOrDefault();
        }

        public IEnumerable<RigOapChecklistQuestionFinding> GetAll(Guid rigChecklistId)
        {
            return (from f in AllItems.Include(f => f.RigOapChecklistQuestion.OapChecklistQuestion)
                   where  f.RigOapChecklistQuestion.RigOapChecklistId == rigChecklistId 
                   select f).ToList();
        }

        public IEnumerable<RigOapChecklistQuestionFinding> GetAllChecklistFindings(Guid rigChecklistId)
        {
            return (from f in AllItems.Include(fi => fi.RigOapChecklistQuestion)
                    where f.RigOapChecklistQuestion.RigOapChecklistId == rigChecklistId
                    select f).ToList();
        }

        public IEnumerable<RigOapChecklistQuestionFinding> GetAllPreviousChecklistQuestionFindings(string rigId, int oapChecklistId, int? questionId)
        {
            return (from f in AllItems.Include(f => f.RigOapChecklistQuestion.OapChecklistQuestion)
                              .Include(f => f.RigOapChecklistQuestion.RigOapChecklist)
                    where f.RigOapChecklistQuestion.OapChecklistQuestion.Id == questionId
                    && f.RigOapChecklistQuestion.RigOapChecklist.OapchecklistId == oapChecklistId
                    select f).ToList();
        }

        public IEnumerable<RigOapChecklistQuestionFinding> GetAllQuestionFindings(Guid rigChecklistQuestionId)
        {
            return (from f in AllItems
                    where f.RigOapChecklistQuestionId == rigChecklistQuestionId
                    select f).ToList();
        }
    }
}
