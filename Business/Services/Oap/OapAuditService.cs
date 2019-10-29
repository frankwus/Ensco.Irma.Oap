using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Data.Repositories.Irma;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Audit;
using System.Collections.Generic;
using System.Linq;
using Ensco.Irma.Models.Domain.Oap;

namespace Ensco.Irma.Services.Oap
{
    public class OapAuditService: HistoricalEntityIdService<IrmaOapDbContext, IOapAuditRepository, OapAudit, int>, IOapAuditService
    {
        public IPeopleRepository PeopleRepository { get; }
        public IPobPersonnelRepository PobPersonnelRepository { get; }

        public IRigOapChecklistService AuditChecklistService { get; }

        public OapAuditService(IOapAuditRepository repository,
            IPeopleRepository peopleRepository, 
            IPobPersonnelRepository pobPersonnelRepository, IRigOapChecklistService auditChecklistService) : base(repository)
        {
            PeopleRepository = peopleRepository;
            PobPersonnelRepository = pobPersonnelRepository;
            AuditChecklistService = auditChecklistService;
        }

        public IEnumerable<OapAudit> GetAllByStatus(string status)
        {
            return Repository.GetAllByStatus(status);
        }

        public OapAudit GetAudit(int id)
        {
            var result =  Repository.GetCompleteAudit(id);

            foreach (var p in result.OapAuditProtocols)
            {
                p.RigOapChecklist.Owner = PeopleRepository.Get(p.RigOapChecklist.OwnerId);

                if ((p.RigOapChecklist.Assessors != null) && p.RigOapChecklist.Assessors.Any())
                {
                    foreach (var a in p.RigOapChecklist.Assessors)
                    {
                        a.TourId = PobPersonnelRepository.GetTourId(a.UserId);
                        a.User = PeopleRepository.Get(a.UserId);
                    }
                }
            }

            return result;
        }

        public override int Add(OapAudit entity)
        {
            AuditChecklistService.Add(entity.OapAuditProtocols.ToList()[0].RigOapChecklist);

            return base.Add(entity);
        }

        public RigChecklistValidationResult ValidateAuditProtocols(int auditId)
        { 
            RigChecklistValidationResult validationResult = new RigChecklistValidationResult();
            var audit = Repository.Get(auditId);
           // var notValid = false;

            if (audit == null)
            {
                validationResult.AddError("Audit not found");
                return validationResult;
            }
            foreach (var ap in audit.OapAuditProtocols)
            {
                if (ap.RigOapChecklist?.OapChecklist?.OapType?.Code == "AR")
                {
                    var checklist = ap.RigOapChecklist;

                    if (checklist.Assessors.Count(a => a.IsLead) == 0)
                    {
                        validationResult.AddError("There must be at least one lead assessor");
                       // notValid = true;
                    }
                    if (checklist.Questions.Any(q => q.Answers.Any(a => string.IsNullOrEmpty(a.Value))))
                    {
                        validationResult.AddError("All checklists questions must be answered");

                        return validationResult;
                    }
                }

            }
            return validationResult;
          //  ValidateAuditAnswers(audit, validationResult);

           
        }
        private void ValidateAuditAnswers(OapAudit audit, RigChecklistValidationResult validationResult)
        {
           // if (checklist.Questions.Any(q => q.Answers.Any(a => string.IsNullOrEmpty(a.Value))))
           foreach(var ap in audit.OapAuditProtocols)
            {
                var checklist = ap.RigOapChecklist;
                if (checklist.Assessors.Count(a => a.IsLead) == 0)
                    validationResult.AddError("There must be at least one lead assessor");
                if (checklist.Questions.Any(q => q.Answers.Any(a => string.IsNullOrEmpty(a.Value))))
                    validationResult.AddError("All checklist questions must be answered");

            }
               
        }


    }
}
