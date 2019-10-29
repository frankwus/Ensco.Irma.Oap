using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Services.Oap
{
    public class RigOapChecklistQuestionFindingService : EntityIdService<IrmaOapDbContext, IRigOapChecklistQuestionFindingRepository, RigOapChecklistQuestionFinding, Guid>, IRigOapChecklistQuestionFindingService
    {
        public RigOapChecklistQuestionFindingService(IRigOapChecklistQuestionFindingRepository findingRepository, IAdminCustomRepository adminCustomRepository, IPeopleRepository peopleRepository, IRigOapChecklistQuestionRepository rigChecklistQuestionRepository) : base(findingRepository)
        {
            AdminCustomRepository = adminCustomRepository;
            PeopleRepository = peopleRepository;
            RigChecklistQuestionRepository = rigChecklistQuestionRepository;
        }

        public IAdminCustomRepository AdminCustomRepository { get; }
        public IPeopleRepository PeopleRepository { get; }
        public IRigOapChecklistQuestionRepository RigChecklistQuestionRepository { get; }

        public override Guid Add(RigOapChecklistQuestionFinding entity)
        {
            var rigManagerPassport = AdminCustomRepository.GetByName("RigManager")?.Value;

            if (!string.IsNullOrEmpty(rigManagerPassport))
            {
                entity.ReviewedByUserId = PeopleRepository.GetByLogin(rigManagerPassport)?.Id??0;
            }

            return base.Add(entity);
        }

        public IEnumerable<RigOapChecklistQuestionFinding> GetAll(Guid rigChecklistId)
        {
            return Repository.GetAll(rigChecklistId);
        }

        public IEnumerable<RigOapChecklistQuestionFinding> GetAllChecklistFindings(Guid rigChecklistId)
        {
            return Repository.GetAllChecklistFindings(rigChecklistId);
        }

        public IEnumerable<RigOapChecklistQuestionFinding> GetAllQuestionFindings(Guid rigChecklistQuestionId)
        {
            return Repository.GetAllQuestionFindings(rigChecklistQuestionId);
        }

        public IEnumerable<RigOapChecklistQuestionFinding> GetAllQuestionPreviousFindings(Guid rigChecklistQuestionId)
        {
            var question = RigChecklistQuestionRepository.GetChecklistQuestionRigDetails(rigChecklistQuestionId);

            return null; // Repository.GetAllPreviousChecklistQuestionFindings(question.RigOapChecklist.RigId, question.RigOapChecklist.OapchecklistId, question.OapChecklistQuestionId); 
        }
    }
}
