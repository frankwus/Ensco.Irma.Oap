using System;
using System.Collections.Generic;
using System.Linq;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services;
using Ensco.Irma.Interfaces.Services.Irma;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Interfaces.Services.Oap.DPA;
using Ensco.Irma.Interfaces.Services.Security;
using Ensco.Irma.Models.Domain.IRMA;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class RigOapChecklistWorkflowService : EntityService<IrmaOapDbContext, IRigOapChecklistWorkflowRepository, RigOapChecklistWorkflow, Guid>, IRigOapChecklistWorkflowService
    {
        private readonly IRigOapChecklistRepository checklistRepository;
        private readonly IIrmaTaskService irmaTaskService;
        private readonly IPeopleService peopleService;
        private readonly IOapDPAService dpaService;
        private readonly IAdminCustomRepository adminCustomRepository;
        private readonly IReviewService reviewService;

        public RigOapChecklistWorkflowService(
            IRigOapChecklistWorkflowRepository rigOapChecklistWorkflowRepository, 
            IRigOapChecklistRepository checklistRepository,
            IIrmaTaskService irmaTaskService,
            IPeopleService peopleService,
            IOapDPAService dpaService,
            IAdminCustomRepository adminCustomRepository,
            IReviewService reviewService) : base(rigOapChecklistWorkflowRepository)
        {
            this.checklistRepository = checklistRepository;
            this.irmaTaskService = irmaTaskService;
            this.peopleService = peopleService;
            this.dpaService = dpaService;
            this.adminCustomRepository = adminCustomRepository;
            this.reviewService = reviewService;
        }
         
        public RigOapChecklistWorkflow GetWorkflowByChecklist(Guid rigChecklistId)
        {
            return Repository.GetWorkflowByChecklist(rigChecklistId);
        }        

        public void StartChecklistWorkFlow(RigOapChecklist checklist)
        {
            var _checklist = checklistRepository.Get(checklist.Id);

            if (checklist == null) return;

            _checklist.Status = WorkflowStatus.Pending.ToString();

            RigOapChecklistAssessor leadAssessor = null;
            foreach (var a in _checklist.Assessors)
            {
                if (a.IsLead)
                {
                    leadAssessor = a;
                    break;
                }
            }

            if (leadAssessor != null)
            {
                irmaTaskService.Add(new IrmaTask
                {
                    Source = "Oap - Workflow",
                    SourceId = _checklist.RigChecklistUniqueId.ToString(),
                    AssigneeId = leadAssessor.UserId,
                    AssignedDateTime = DateTime.UtcNow,
                    Comment = $"You have been assigned checklist {_checklist.RigChecklistUniqueId} for review/approval",
                    Status = "Open"
                });
            }

            var firstVerifier = _checklist.VerifiedBy.OrderBy(v => v.Order).FirstOrDefault();
            firstVerifier.Status = WorkflowStatus.Pending.ToString();

            var assessorEmail = peopleService.Get(leadAssessor.UserId).Email;
            irmaTaskService.SendEmail(assessorEmail, "Rig Checklist Verfication", $"You have been assigned to checklist {_checklist.RigChecklistUniqueId} for review.");                        

            checklistRepository.Update(_checklist);

        }

        public void SignWorkFlow(RigOapChecklist existingRigChecklist, int userId, int order, string comment)
        {
            var verifier = existingRigChecklist.VerifiedBy.ToList().FirstOrDefault(v => v.UserId == userId);

            if (verifier == null) return;            

            // Close task and mark the next user's task as pending
            var existingTask = irmaTaskService.CloseTask("Oap - Workflow", existingRigChecklist.RigChecklistUniqueId, userId);
            var nextSigner = existingRigChecklist.VerifiedBy.OrderBy(v => v.Order).FirstOrDefault(v => v.Order > verifier.Order);
            //var nextSignerTask = irmaTaskService.Filter(t => t.Source == "Oap - Workflow" && t.SourceId == existingRigChecklist.RigChecklistUniqueId && t.AssigneeId == nextSigner.UserId).FirstOrDefault();

            verifier.SignedOn = DateTime.UtcNow;
            verifier.UpdatedDateTime = DateTime.UtcNow;
            verifier.Status = WorkflowStatus.Completed.ToString();
            verifier.Comment = comment;

            if (nextSigner != null)
                nextSigner.Status = WorkflowStatus.Pending.ToString();

            checklistRepository.Update(existingRigChecklist);
        }

        public void RejectWorkFlow(RigOapChecklist checklist, int userId, int order, string comment)
        {
            // Closes existing user task            
            irmaTaskService.CloseTask("Oap - Workflow", checklist.RigChecklistUniqueId, userId);

            //Reverse to the previous verifier            
            var currentSigner = checklist.VerifiedBy.ToList().FirstOrDefault(v => v.UserId == userId && v.Order == order);
            var previousSigner = checklist.VerifiedBy.ToList().OrderByDescending(v => v.Order).FirstOrDefault(v => v.Order < order);

            currentSigner.Status = WorkflowStatus.Rejected.ToString();
            currentSigner.SignedOn = DateTime.UtcNow;
            currentSigner.UpdatedDateTime = DateTime.UtcNow;
            currentSigner.Comment = comment;

            previousSigner.Status = WorkflowStatus.Pending.ToString();
            previousSigner.SignedOn = null;
            previousSigner.UpdatedDateTime = DateTime.UtcNow;

            irmaTaskService.Add(new Models.Domain.IRMA.IrmaTask
            {
                Source = "Oap - Workflow",
                SourceId = checklist.RigChecklistUniqueId.ToString(),
                AssigneeId = previousSigner.UserId,
                AssignedDateTime = DateTime.UtcNow,
                Comment = $"The checklist {checklist.RigChecklistUniqueId} was rejected, please review it before resubmitting",
                Status = "Open"
            });

            checklistRepository.Update(checklist);
        }

        public void Review(RigOapChecklist checklist, int userId, int order, string comment)
        {
            var verifier = checklist.VerifiedBy.ToList().FirstOrDefault(v => v.UserId == userId && v.Order == order);

            if (verifier == null) return;

            // Update / close task
            irmaTaskService.CloseTask("Oap - Workflow", checklist.RigChecklistUniqueId, userId);

            verifier.SignedOn = DateTime.UtcNow;
            verifier.UpdatedDateTime = DateTime.UtcNow;
            verifier.Status = WorkflowStatus.Completed.ToString();
            verifier.Comment = comment;

            bool hasNextVerifier = checklist.VerifiedBy.ToList().OrderBy(v => v.Order).Any(v => v.Order > order);
            if (hasNextVerifier == false)
                checklist.Status = ChecklistStatus.Completed.ToString();

            // Assign Task to Rig DPAs to review the checklist "No" answers
            if (!hasNextVerifier && checklist.OapChecklist.Name.Contains("Master Oversight"))
            {
                AssignReviewAndTasksToRigDPAs(checklist);
                AssignReviewAndTasksToOIM(checklist);
            }

            if (!hasNextVerifier && checklist.OapChecklist.Name.Contains("Audit Report"))
            {
                AssignReviewAndTasksToAuditOIM(checklist);
            }

            checklistRepository.Update(checklist);
        }

        private void AssignReviewAndTasksToOIM(RigOapChecklist checklist)
        {
            string oimPassport = adminCustomRepository.GetByName("OIM")?.Value;
            var oimUser = peopleService.GetByLogin(oimPassport);

            if (oimPassport != null && oimUser != null)
            {
                irmaTaskService.Add(new IrmaTask()
                {
                    Source = "Oap",
                    SourceId = checklist.Id.ToString(),
                    SourceUrl = string.Format("/Oap/MasterOversight/List/{0}", checklist.Id), // Needs improvement - Does not have access to the MVC routing from the api
                    AssigneeId = oimUser.Id,
                    Comment = string.Format("Master Oversight checklist {0} has been submitted and is available for your review", checklist.RigChecklistUniqueId),
                    AssignedDateTime = DateTime.UtcNow,
                    Status = "Open"
                });

                int rigId;
                reviewService.Add(new IrmaReview()
                {
                    ReviewerPassportId = oimUser.Id,
                  //  RigId = rigId,
                    SourceForm = "Oap",
                    SourceFormId = checklist.Id.ToString(),
                });
            }

        }

        private void AssignReviewAndTasksToAuditOIM(RigOapChecklist checklist)
        {
            string oimPassport = adminCustomRepository.GetByName("OIM")?.Value;
            var oimUser = peopleService.GetByLogin(oimPassport);
            //get audit info from checklist id and then assign below audit values
            if (oimPassport != null && oimUser != null)
            {
                irmaTaskService.Add(new IrmaTask()
                {
                    Source = "cOap",
                    SourceId = checklist.Id.ToString(),
                    SourceUrl = string.Format("/cOap/OapAuditReport/Index/{0}", checklist.Id), // Needs improvement - Does not have access to the MVC routing from the api
                    AssigneeId = oimUser.Id,
                    Comment = string.Format("Audit {0} has been submitted and is available for your review", checklist.RigChecklistUniqueId),
                    AssignedDateTime = DateTime.UtcNow,
                    Status = "Open"
                });

                int rigId;
                int.TryParse(checklist.RigId, out rigId);
                reviewService.Add(new IrmaReview()
                {
                    ReviewerPassportId = oimUser.Id,
                    RigId = rigId,
                    SourceForm = "Oap",
                    SourceFormId = checklist.Id.ToString(),
                });
            }

        }

        private void AssignReviewAndTasksToRigDPAs(RigOapChecklist checklist)
        {
            var checklistQuestionWithNoAnswers = from questions in checklist.Questions
                                                 from answers in questions.Answers
                                                 where answers.Value == "N"
                                                 select questions;

            if (checklistQuestionWithNoAnswers.Any())
            {
                int rigId;
                int.TryParse(adminCustomRepository.GetByName("RigId").Value, out rigId);
                if (rigId == 0) return;

                var rigDPAs = dpaService.GetAllRigDPAs(rigId);
                foreach (var dpa in rigDPAs)
                {   
                    irmaTaskService.Add(new IrmaTask()
                    {
                        Source = "Oap",
                        SourceId = checklist.Id.ToString(),
                        SourceUrl = string.Format("/Oap/MasterOversight/List/{0}", checklist.Id), // Needs improvement - Does not have access to the MVC routing from the api
                        AssigneeId = dpa.UserId,
                        Comment = string.Format("Master Oversight checklist {0} has a 'NO' answer that needs your review", checklist.RigChecklistUniqueId),
                        AssignedDateTime = DateTime.UtcNow,
                        Status = "Open"
                    });

                    reviewService.Add(new IrmaReview()
                    {
                        ReviewerPassportId = dpa.UserId,
                        RigId = rigId,
                        SourceForm = "Oap",
                        SourceFormId = checklist.Id.ToString(),
                    });
                }
            }
        }

        public void Cancel(RigOapChecklist checklist, int userId, int order, string comment)
        {
            var verifier = checklist.VerifiedBy.FirstOrDefault(v => v.Order == order && v.UserId == userId);
            irmaTaskService.CloseTask("Oap - Workflow", checklist.RigChecklistUniqueId, userId);

            verifier.Status = WorkflowStatus.Canceled.ToString();
            verifier.SignedOn = DateTime.UtcNow;
            verifier.UpdatedDateTime = DateTime.UtcNow;
            verifier.Comment = comment;

            checklist.Status = ChecklistStatus.Canceled.ToString();

            checklistRepository.Update(checklist);
        }

        public void UpdateRigChecklistsStatus(IEnumerable<RigOapChecklist> rList)
        {
            foreach (var checklist in rList)
            {
                checklist.Status = ChecklistStatus.Completed.ToString();
                checklistRepository.Update(checklist);
            }
        }

    }
}
