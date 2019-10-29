using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.IRMA;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System;
using System.Collections.Generic;
using System.Linq;
using Ensco.Irma.Extensions;
using Ensco.Irma.Data.Repositories;
using Ensco.Irma.Interfaces.Data.Repositories.Irma;
using Ensco.Irma.Models.Domain.Oap;

namespace Ensco.Irma.Services.Oap
{
    public class RigOapChecklistService : EntityIdService<IrmaOapDbContext, IRigOapChecklistRepository, RigOapChecklist, Guid>, IRigOapChecklistService
    {
        private readonly IRigOapChecklistAssessorRepository assessorRepository;

        public RigOapChecklistService(IRigOapChecklistRepository rigOapChecklistRepository,
                IPeopleRepository peopleRepository,
                IAdminCustomRepository adminCustomRepository,
                IOapChecklistQuestionRelatedQuestionMapRepository oapChecklistQuestionRelatedQuestionMapRepository,
                IOapChecklistRepository oapChecklistRepository,
                IRigOapChecklistQuestionRepository rigOapChecklistQuestionRepository,
                IRigOapChecklistQuestionAnswerRepository rigOapChecklistQuestionAnswerRepository,
                IRigOapChecklistGroupAssetRepository rigOapChecklistGroupAssetRepository,
                IOapChecklistAssetDataManagementRepository oapChecklistAssetDataManagementRepository,
                IOapChecklistWorkInstructionRepository oapChecklistWorkInstructionRepository,
                IRigOapChecklistWorkInstructionRepository rigOapChecklistWorkInstructionRepository,
                IOapChecklistReviewerRepository oapChecklistReviewerRepository,
                IPobPersonnelRepository pobPersonnelRepository,
                IRigOapChecklistAssessorRepository assessorRepository
            ) : base(rigOapChecklistRepository)
        {
            PeopleRepository = peopleRepository;
            OapChecklistQuestionRelatedQuestionMapRepository = oapChecklistQuestionRelatedQuestionMapRepository;
            OapChecklistRepository = oapChecklistRepository;
            RigOapChecklistQuestionRepository = rigOapChecklistQuestionRepository;
            RigOapChecklistGroupAssetRepository = rigOapChecklistGroupAssetRepository;
            OapChecklistAssetDataManagementRepository = oapChecklistAssetDataManagementRepository;
            OapChecklistWorkInstructionRepository = oapChecklistWorkInstructionRepository;
            RigOapChecklistWorkInstructionRepository = rigOapChecklistWorkInstructionRepository;
            OapChecklistReviewerRepository = oapChecklistReviewerRepository;
            PobPersonnelRepository = pobPersonnelRepository;
            this.assessorRepository = assessorRepository;
            AdminCustomRepository = adminCustomRepository;
            QuestionAnswerRepository = rigOapChecklistQuestionAnswerRepository;
        }

        public IPeopleRepository PeopleRepository { get; }
        public IOapChecklistQuestionRelatedQuestionMapRepository OapChecklistQuestionRelatedQuestionMapRepository { get; }
        public IOapChecklistRepository OapChecklistRepository { get; }
        public IRigOapChecklistQuestionRepository RigOapChecklistQuestionRepository { get; }
        public IRigOapChecklistGroupAssetRepository RigOapChecklistGroupAssetRepository { get; }
        public IOapChecklistAssetDataManagementRepository OapChecklistAssetDataManagementRepository { get; }
        public IOapChecklistWorkInstructionRepository OapChecklistWorkInstructionRepository { get; }
        public IRigOapChecklistWorkInstructionRepository RigOapChecklistWorkInstructionRepository { get; }
        public IOapChecklistReviewerRepository OapChecklistReviewerRepository { get; }
        public IPobPersonnelRepository PobPersonnelRepository { get; }
        public IAdminCustomRepository AdminCustomRepository { get; }
        public IRigOapChecklistQuestionAnswerRepository QuestionAnswerRepository { get; }

        public IEnumerable<RigOapChecklist> GetAll(string status)
        {
            return Repository.GetAll(status);
        }
        public IEnumerable<RigOapChecklist> GetAll(string status, DateTime checklistDate)
        {
            var checklists = Repository.GetAll(status, checklistDate);
            if (checklists.Any())
            {
                foreach (var c in checklists)
                {
                    PopulateUser(c);
                }
            }
            return checklists;
        }
        public RigOapChecklist GetByUniqueId(int uniqueId)
        {
            return Repository.GetByUniqueId(uniqueId);
        }
        public IEnumerable<RigOapChecklist> GetByTypeStatus(string typeName, string status)
        {
            bool returnAllStatus = status.ToLower() == "all";
            return
                Repository.GetQueryable(c => (c.OapChecklist.OapType.Name.ToLower().Contains(typeName.ToLower()) || c.OapChecklist.OapSubType.Name.ToLower().Contains(typeName.ToLower())) && (returnAllStatus ? true : c.Status.ToLower().Equals(status.ToLower()))).AsEnumerable();
        }

        public IEnumerable<RigOapChecklist> GetByTypeSubType(string typeCode, string subTypeName, string status)
        {
            var checklists = Repository.GetByTypeSubType(typeCode, subTypeName, status);

            checklists.ToList().ForEach((c) =>
            {
                PopulateUser(c);
            });

            return checklists;
        }
        public IEnumerable<RigOapChecklist> GetByTypeSubTypeCode(string typeCode, string subTypeCode, string status)
        {
            var checklists = Repository.GetByTypeSubTypeCode(typeCode, subTypeCode, status).ToList();

            checklists.ForEach((c) =>
            {
                PopulateUser(c);
            });

            return checklists;
        }
        public IEnumerable<RigOapChecklist> GetByTypeSubTypeFormType(string typeName, string subTypeName, string formType, string status)
        {
            var checklists = Repository.GetByTypeSubTypeFormType(typeName, subTypeName, formType, status);

            checklists.ToList().ForEach((c) =>
            {
                PopulateUser(c);
            });

            return checklists;
        }
        public IEnumerable<RigOapChecklist> GetByTypeSubTypeCodeFormType(string typeCode, string subTypeCode, string formType, string status)
        {
            var checklists = Repository.GetByTypeSubTypeCodeFormType(typeCode, subTypeCode, formType, status).ToList();

            checklists.ForEach((c) =>
            {
                PopulateUser(c);
            });

            return checklists;
        }
        public RigOapChecklist GetCompleteChecklist(Guid rigCheckListId)
        {
            var rigChecklist = Repository.GetCompleteChecklist(rigCheckListId);

            //if (rigChecklist.OapChecklist?.Groups != null)
            //{
            //    foreach (var g in rigChecklist.OapChecklist?.Groups)
            //    {
            //        if (!string.IsNullOrEmpty(g.OapGraphic?.ImageLocation))
            //        {
            //            g.OapGraphic.Image = g.OapGraphic.ImageLocation.Get();
            //        }
            //    }
            //}

            ////Process some BAC rules
            //if (rigChecklist.OapChecklist != null && rigChecklist.Status.Equals(ChecklistStatus.Open.ToString(), StringComparison.InvariantCultureIgnoreCase))
            //{
            //    var oapType = rigChecklist.OapChecklist.OapType.Code;

            //    switch (oapType)
            //    {
            //        case "BAC":
            //            var answerOrdinal = DateTime.Today.Subtract(rigChecklist.ChecklistDateTime).Days;
            //            if (answerOrdinal < 7)
            //            {
            //                var activeRigOapChecklistsWithNoAnswers = Repository.GetGetAllActiveChecklistsWithNoQuestions(rigChecklist.OapchecklistId);
            //                ApplyBacNoControlLogic(rigChecklist, activeRigOapChecklistsWithNoAnswers, answerOrdinal);
            //                var lastRigOapChecklist = Repository.GetLastChecklistWithQuestions(rigChecklist.OapchecklistId, rigChecklist.ChecklistDateTime);
            //                ApplyBacNoControlLogic(rigChecklist, new List<RigOapChecklist>() { lastRigOapChecklist }, answerOrdinal);

            //                if (Repository.HasChanged(rigChecklist))
            //                {
            //                    Repository.Update(rigChecklist);
            //                }
            //            }
            //            break;

            //        case "OIM":
            //        case "OM":
            //            break;
            //    }
            //}

            return rigChecklist;
        }
        public IEnumerable<RigOapChecklist> GetOpenFsoChecklists(int fsoChecklistId)
        {
            return Repository.GetOpenFsoChecklist(fsoChecklistId);
        }
        private void PopulateUser(RigOapChecklist rigOapChecklist)
        {
            if (rigOapChecklist == null)
            {
                return;
            }

            rigOapChecklist.Owner = PeopleRepository.Get(rigOapChecklist.OwnerId);


            if ((rigOapChecklist.Assessors != null) && rigOapChecklist.Assessors.Any())
            {
                foreach (var a in rigOapChecklist.Assessors)
                {
                    a.TourId = PobPersonnelRepository.GetTourId(a.UserId);
                    a.User = PeopleRepository.Get(a.UserId);
                }
            }

            if ((rigOapChecklist.VerifiedBy != null) && rigOapChecklist.VerifiedBy.Any())
            {
                foreach (var v in rigOapChecklist.VerifiedBy)
                {
                    v.User = PeopleRepository.Get(v.UserId);
                }
            }
        }
        public IEnumerable<RigOapChecklistQuestion> GetRelatedQuestionSearch(int questionId, DateTime fromDate, DateTime toDate, string searchBy)
        {
            var relatedRigOapChecklistQuestions = new List<RigOapChecklistQuestion>();
            if (searchBy == "Mapping")
            {
                var relatedQuestions = OapChecklistQuestionRelatedQuestionMapRepository.GetRelatedQuestions(questionId);

                foreach (var q in relatedQuestions)
                {
                    relatedRigOapChecklistQuestions.AddRange(RigOapChecklistQuestionRepository.GetAllQuestions(q.Id, fromDate, toDate));
                }
            }
            else if (searchBy == "Historical")
            {
                relatedRigOapChecklistQuestions.AddRange(RigOapChecklistQuestionRepository.GetAllQuestions(questionId, fromDate, toDate));
            }

            return relatedRigOapChecklistQuestions;
        }
        public IEnumerable<RigOapChecklist> GetFsoChecklistByMindate(DateTime minDate, int oapChecklistId)
        {
            return Repository.GetFsoChecklistByMinDate(minDate, oapChecklistId);
        }
        public override Guid Add(RigOapChecklist rigChecklist)
        {
            var oapChecklist = OapChecklistRepository.GetCompleteChecklist(rigChecklist.OapchecklistId);

            rigChecklist.Status = rigChecklist.Status ?? ChecklistStatus.Open.ToString();

            //rigChecklist.RigId = rigChecklist.RigId !="0"? rigChecklist.RigId: AdminCustomRepository.GetByName("RigId").Value;
           // var rigId = AdminCustomRepository.GetByName("RigId").Value;
           // rigChecklist.RigId = rigId;

            AddQuestionsToChecklist(rigChecklist, oapChecklist);
            AddCommentsToChecklist(rigChecklist, oapChecklist);

            if (rigChecklist.OwnerId != 0)
                AssignOwnerAsLeadAssessor(rigChecklist, oapChecklist);

            if (oapChecklist.OapType?.Code == "OIM" | oapChecklist.OapSubType?.Code == "OIM") // OIM Oversight
            {
                AddOIMToChecklist(rigChecklist);
                AddRigManagerToChecklist(rigChecklist);
            } else if (oapChecklist.Name.Contains("Master Oversight")) // Master Oversight
            {
                AddMasterToChecklist(rigChecklist);
                AddRigManagerToChecklist(rigChecklist);
            }
            else
            {
                AssignOwnerAsVerifier(rigChecklist);
                AddOIMToChecklist(rigChecklist);
            }


            var rigChecklistId = base.Add(rigChecklist);

            switch (oapChecklist.OapType.Code)
            {
                case "BAC":
                    ProcessBACChecklist(rigChecklist, oapChecklist);
                    break;

            }

            return rigChecklistId;
        }        

        //To add Protocols for an audit
        public Guid AddProtocol(RigOapChecklist rigChecklist)
        {
            var oapChecklist = OapChecklistRepository.GetCompleteChecklist(rigChecklist.OapchecklistId);

            rigChecklist.Status = rigChecklist.Status ?? ChecklistStatus.Open.ToString();

            AddQuestionsToChecklist(rigChecklist, oapChecklist);
            AddCommentsToChecklist(rigChecklist, oapChecklist);

            if (rigChecklist.OwnerId != 0)
                AssignOwnerAsLeadAssessor(rigChecklist, oapChecklist);           

            var rigChecklistId = base.Add(rigChecklist);

            return rigChecklistId;
        }

        private void AddCommentsToChecklist(RigOapChecklist rigChecklist, OapChecklist oapChecklist)
        {
            if (((rigChecklist.Comments == null) || ((rigChecklist.Comments != null) && !rigChecklist.Comments.Any())) && (rigChecklist.Questions == null && oapChecklist?.Comments != null))
            {
                rigChecklist.Comments = (from c in oapChecklist.Comments
                                         select new RigOapChecklistComment()
                                         {
                                             Id = Guid.NewGuid(),
                                             RigOapChecklist = rigChecklist,
                                             RigOapChecklistId = rigChecklist.Id,
                                             OapChecklistCommentId = c.Id,
                                             OapChecklistComment = c
                                         }).ToList();
            }

        }
        private void AddQuestionsToChecklist(RigOapChecklist rigChecklist, OapChecklist oapChecklist)
        {
            if (
                    ((rigChecklist.Questions == null)
                        || ((rigChecklist.Questions != null) && !rigChecklist.Questions.Any()))
                    &&
                    (rigChecklist.Questions == null && oapChecklist.Groups.Any(g => g.SubGroups.Any(sg => sg.Topics.Any(t => t.Questions.Any()))))
                )
            {

                int answersCount = 1;
                switch (oapChecklist.OapType.Code)
                {
                    case "BAC":
                        answersCount = 7;
                        break;
                    case "OIM":
                    case "OM":
                        answersCount = 4;
                        break;
                }

                rigChecklist.Questions = (from groups in oapChecklist.Groups
                                          from subGroups in groups.SubGroups
                                          from topics in subGroups.Topics
                                          from question in topics.Questions
                                          where subGroups != null & topics != null && question != null
                                          select new RigOapChecklistQuestion()
                                          {
                                              Id = Guid.NewGuid(),
                                              RigOapChecklist = rigChecklist,
                                              RigOapChecklistId = rigChecklist.Id,
                                              OapChecklistQuestionId = question.Id,
                                              OapChecklistQuestion = question,
                                              Answers = GetAnswers(answersCount)
                                          }).ToList();

                if (oapChecklist.OapType.Code == "BAC")
                {
                    var activeRigOapChecklistsWithNoAnswers = Repository.GetGetAllActiveChecklistsWithNoQuestions(rigChecklist.OapchecklistId);
                    ApplyBacNoControlLogic(rigChecklist, activeRigOapChecklistsWithNoAnswers);
                    var lastRigOapChecklist = Repository.GetLastChecklistWithQuestions(rigChecklist.OapchecklistId, rigChecklist.ChecklistDateTime);
                    ApplyBacNoControlLogic(rigChecklist, new List<RigOapChecklist>() { lastRigOapChecklist });
                }
            }

        }
        private void ApplyBacNoControlLogic(RigOapChecklist rigChecklist, IEnumerable<RigOapChecklist> rigOapChecklistsWithQuestions, int answerOrdinal = 0)
        {
            if (rigOapChecklistsWithQuestions == null)
            {
                return;
            }

            if (!rigOapChecklistsWithQuestions.Any())
            {
                return;
            }

            foreach (var q in rigChecklist.Questions)
            {
                var questionswithnoanswers = (from ncl in rigOapChecklistsWithQuestions
                                              from nq in ncl.Questions
                                              where nq.OapChecklistQuestionId == q.OapChecklistQuestionId && nq.Answers.Where(na => string.IsNullOrEmpty(na.Value)).LastOrDefault().Value == "N"
                                              select nq).ToList();
                if (questionswithnoanswers.Any())
                {
                    var questionwithNoAnswer = questionswithnoanswers.First();
                    q.Answers.ToList()[answerOrdinal].Value = "N";
                    //q.NoAnswerComment = questionwithNoAnswer.NoAnswerComment;
                }
            }
        }
        private IList<RigOapChecklistQuestionAnswer> GetAnswers(int answerCount)
        {
            var answers = new List<RigOapChecklistQuestionAnswer>();

            for (int i = 0; i < answerCount; i++)
            {
                var value = string.Empty;


                answers.Add(new RigOapChecklistQuestionAnswer()
                {
                    Id = Guid.NewGuid(),
                    Ordinal = i,
                    Value = value
                });
            }

            return answers;
        }
        public override RigOapChecklist Update(RigOapChecklist entity)
        {
            //if the owner is differnt from leadAssessor that has been selected
            AssignLeadAssessorAsOwner(entity);

            return base.Update(entity);
        }
        private void AssignLeadAssessorAsOwner(RigOapChecklist checklist)
        {
            var assessors = checklist.Assessors.ToList();
            var leadAssessor = assessors.FirstOrDefault(a => a.IsLead);

            if ((leadAssessor != null) && leadAssessor.UserId != checklist.OwnerId)
            {
                checklist.OwnerId = leadAssessor.UserId;
            }

        }
        private void AssignOwnerAsLeadAssessor(RigOapChecklist checklist, OapChecklist oapChecklist)
        {
            var ownerId = checklist.OwnerId;

            var leadAssessor = new RigOapChecklistAssessor()
            {
                UserId = ownerId,
                IsLead = true,
                Role = VerifierRole.Assessor.ToString()

            };

            if (checklist.Assessors?.Any() == null)
            {
                checklist.Assessors = new List<RigOapChecklistAssessor>
                {
                    leadAssessor
                };

                return;
            }

            var assessors = checklist.Assessors.ToList();
            var assessor = assessors.FirstOrDefault(a => a.IsLead && a.UserId != ownerId);

            if (assessor == null)
            {
                var order = (checklist.VerifiedBy.Any()) ? checklist.VerifiedBy?.Max(v => v.Order) ?? 0 : 0;

                checklist.Assessors.Add(leadAssessor);
            }


        }
        private void AssignOwnerAsVerifier(RigOapChecklist checklist)
        {
            if (checklist.OwnerId == 0)
                return;

            var ownerId = checklist.OwnerId;
            var order = (checklist.VerifiedBy.Any()) ? checklist.VerifiedBy?.Max(v => v.Order) ?? 0 : 0;

            var verifier = checklist.VerifiedBy?.FirstOrDefault(a => a.Role.Equals(VerifierRole.Assessor.ToString(), StringComparison.InvariantCultureIgnoreCase) && a.UserId != ownerId);
            if (verifier == null)
            {
                if (checklist.VerifiedBy == null)
                {
                    checklist.VerifiedBy = new List<RigOapChecklistVerifier>();
                }

                verifier = new RigOapChecklistVerifier()
                {
                    UserId = ownerId,
                    Role = VerifierRole.Assessor.ToString(),
                    Order = order + 1
                };

                checklist.VerifiedBy.Add(verifier);
            }
        }
        private void ProcessBACChecklist(RigOapChecklist rigOapChecklist, OapChecklist oapChecklist)
        {
            AddPlantMonitoringActivities(rigOapChecklist.Id, oapChecklist);
           // AddWorkInstructions(rigOapChecklist.Id, rigOapChecklist.RigId, oapChecklist);
            AddReviewersToChecklist(rigOapChecklist);
        }
        private void AddPlantMonitoringActivities(Guid rigOapChecklistId, OapChecklist oapChecklist)
        {
            var plantSubgroupId = (from g in oapChecklist.Groups
                                   from sg in g.SubGroups
                                   where sg.IsPlantMonitoring == true
                                   select g.Id).FirstOrDefault();

            if (plantSubgroupId <= 0)
            {
                return;
            }

            var oChecklistADM = OapChecklistAssetDataManagementRepository.GetAssetsByGroup(plantSubgroupId);

            if (oChecklistADM?.Any() == false)
            {
                return;
            }

            var assets = (from oadm in oChecklistADM
                          select new RigOapChecklistGroupAsset()
                          {
                              RigOapChecklistId = rigOapChecklistId,
                              AssetId = oadm.Id
                          }).ToList();

            assets.ForEach(a =>
            {
                RigOapChecklistGroupAssetRepository.Add(a);
            });
        }
        private void AddWorkInstructions(Guid rigOapChecklistId, string rigId, OapChecklist oapChecklist)
        {
            var plantSubgroupId = (from g in oapChecklist.Groups
                                   from sg in g.SubGroups
                                   where sg.IsWorkInstructions == true
                                   select g.Id).FirstOrDefault();

            if (plantSubgroupId <= 0)
            {
                return;
            }

            var oChecklistWorkInstructions = OapChecklistWorkInstructionRepository.GetAllWorkInstructionByChecklistAndRigId(rigId, oapChecklist.Id);

            if (oChecklistWorkInstructions?.Any() == false)
            {
                return;
            }

            var rigWorkInstructions = (from wi in oChecklistWorkInstructions
                                       select new RigOapChecklistWorkInstruction()
                                       {
                                           RigOapChecklistId = rigOapChecklistId,
                                           WorkInstructionId = wi.Id
                                       }).ToList();

            rigWorkInstructions.ForEach(wi =>
            {
                RigOapChecklistWorkInstructionRepository.Add(wi);
            });
        }
        private void AddReviewersToChecklist(RigOapChecklist checklist)
        {
            var reviewerPositions = OapChecklistReviewerRepository.GetActiveReviewerPositions(checklist.RigId.ToString(), checklist.OapchecklistId, DateTime.Today);

            if (!reviewerPositions.Any())
            {
                return;
            }

            var reviewers = PobPersonnelRepository.GetReviewers(checklist.RigId.ToString(), 3, reviewerPositions.Select(r => r.ReviewerPositionId).ToList()).ToList();

            if (!reviewers.Any())
            {
                return;
            }

            var priorVerifiedBy = checklist.VerifiedBy?.Count();

            var order = (checklist.VerifiedBy.Any()) ? checklist.VerifiedBy?.Where(v => v.Role != VerifierRole.OIM.ToString()).Max(v => v.Order) ?? 0 : 0;


            reviewers.ForEach(r =>
            {
                if (r.PobPerson != null)
                {
                    if (!checklist.VerifiedBy.Any(v => v.UserId == r.PobPerson.Id))
                    {
                        checklist.VerifiedBy.Add(new RigOapChecklistVerifier()
                        {
                            RigOapChecklistId = checklist.Id,
                            UserId = r.PobPerson.Id,
                            Role = VerifierRole.Reviewer.ToString(),
                            Order = order + 1
                        });
                        order++;
                    }
                }


            });

            var currentVerifiedBy = checklist.VerifiedBy?.Count() ?? 0;
            if (priorVerifiedBy != currentVerifiedBy)
            {
                Save(checklist);
            }
        }
        private void AddOIMToChecklist(RigOapChecklist rigOapChecklist)
        {
            var oim = AdminCustomRepository.GetByName(VerifierRole.OIM.ToString());

            //OIM 
            if (oim != null)
            {
                if (!string.IsNullOrEmpty(oim.Value))
                {
                    var oimPassport = oim.Value;
                    var oimUser = PeopleRepository.GetByLogin(oimPassport);
                    var oimOrder = rigOapChecklist.VerifiedBy?.Count() + 50 ?? 50;                    

                    if ((rigOapChecklist.VerifiedBy != null) && rigOapChecklist.VerifiedBy.Any())
                    {
                        //Check if the OIM User Exists
                        if (!rigOapChecklist.VerifiedBy.Any(v => v.UserId == oimUser?.Id && v.Role.Equals(oim.Name, StringComparison.InvariantCultureIgnoreCase)))
                        {
                            rigOapChecklist.VerifiedBy.Add(new RigOapChecklistVerifier() { Id = Guid.NewGuid(), RigOapChecklistId = rigOapChecklist.Id, Role = VerifierRole.OIM.ToString(), isReviewer = true, UserId = oimUser.Id, Order = oimOrder });
                        }
                    }
                    else
                    {
                        rigOapChecklist.VerifiedBy = new List<RigOapChecklistVerifier>() { new RigOapChecklistVerifier() { Id = Guid.NewGuid(), RigOapChecklistId = rigOapChecklist.Id, Role = VerifierRole.OIM.ToString(), isReviewer = true, UserId = oimUser.Id, Order = oimOrder } };
                    }

                }
            }

        }
        private void AddMasterToChecklist(RigOapChecklist rigChecklist)
        {
            var master = AdminCustomRepository.GetByName(VerifierRole.Master.ToString());

            if (master != null && !string.IsNullOrEmpty(master.Value))
            {
                var masterPassport = master.Value;
                var masterUser = PeopleRepository.GetByLogin(masterPassport);
                var masterOrder = rigChecklist.VerifiedBy?.Count() + 1 ?? 1;

                rigChecklist.AddVerifier(masterUser.Id, VerifierRole.Master.ToString(), masterOrder);                
            }
        }

        private void AddRigManagerToChecklist(RigOapChecklist rigOapChecklist)
        {
            var rigManager = AdminCustomRepository.GetByName(VerifierRole.RigManager.ToString());

            if (rigManager != null && !string.IsNullOrEmpty(rigManager.Value))
            {                
                var rmPassportId = rigManager.Value;
                var rmUser = PeopleRepository.GetByLogin(rmPassportId);
                var rmOrder = rigOapChecklist.VerifiedBy?.Count() + 100 ?? 100;

                if ((rigOapChecklist.VerifiedBy != null) && rigOapChecklist.VerifiedBy.Any())
                {
                    //Check if the Rig Manager User Exists
                    if (!rigOapChecklist.VerifiedBy.Any(v => v.UserId == rmUser.Id && v.Role.Equals(rigManager.Name, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        rigOapChecklist.VerifiedBy.Add(new RigOapChecklistVerifier() { Id = Guid.NewGuid(), RigOapChecklistId = rigOapChecklist.Id, Role = VerifierRole.RigManager.ToString(), isReviewer = true, UserId = rmUser.Id, Order = rmOrder });
                    }
                }
                else
                {
                    rigOapChecklist.VerifiedBy = new List<RigOapChecklistVerifier>() { new RigOapChecklistVerifier() { Id = Guid.NewGuid(), RigOapChecklistId = rigOapChecklist.Id, Role = VerifierRole.RigManager.ToString(), isReviewer = true, UserId = rmUser.Id, Order = rmOrder } };
                }
            }
        }
        public bool UpdateRigChecklistAnswers(IEnumerable<RigOapChecklistQuestionAnswer> answers)
        {
            foreach (var checklistAnswer in answers)
            {
                if (string.IsNullOrEmpty(checklistAnswer.Value))
                    continue;

                var existingAnswer = QuestionAnswerRepository
                    .Filter(a => a.RigOapChecklistQuestionId == checklistAnswer.RigOapChecklistQuestionId &&
                            a.Ordinal == checklistAnswer.Ordinal).FirstOrDefault();

                if (existingAnswer == null)
                    QuestionAnswerRepository.Add(checklistAnswer);
                else
                {
                    existingAnswer.Value = checklistAnswer.Value;
                    existingAnswer.UpdatedDateTime = DateTime.UtcNow;
                    QuestionAnswerRepository.Update(existingAnswer);
                }
            }
            return true;
        }
        public RigOapChecklist AddAssessor(RigOapChecklistAssessor assessor)
        {
            var checklist = Repository.GetCompleteChecklist(assessor.RigOapChecklistId.Value);
            if (checklist == null)
                throw new Exception("Rig Checklist not found");

            if (checklist.Assessors.Any(a => a.UserId == assessor.UserId))
                throw new Exception("User is already an assessor of this checklist");

            assessor.TourId = PobPersonnelRepository.GetTourId(assessor.UserId);

            // Add to verifiers
            if (assessor.IsLead)
            {
                if (checklist.OapChecklist.Name.ToLower().Contains("OIM Oversight".ToLower())) // OIM Oversight flows from OIM to Rig Manager
                {
                    checklist.VerifiedBy.Add(new RigOapChecklistVerifier()
                    {
                        CreatedDateTime = DateTime.UtcNow,
                        Order = 5,
                        Role = VerifierRole.OIM.ToString(),
                        UserId = assessor.UserId
                    });
                }
                else
                {
                    checklist.VerifiedBy.Add(new RigOapChecklistVerifier()
                    {
                        CreatedDateTime = DateTime.UtcNow,
                        Order = 5,
                        Role = VerifierRole.Assessor.ToString(),
                        UserId = assessor.UserId
                    });
                }

            }

            // Remove current lead assessor from verifiers if any
            if (assessor.IsLead && checklist.Assessors.Any(a => a.IsLead))
            {
                var currentLead = checklist.Assessors.FirstOrDefault(a => a.IsLead);
                currentLead.IsLead = false;
                var currentLeadVerifier = checklist.VerifiedBy.FirstOrDefault(a => a.UserId == currentLead.UserId);
                if (currentLeadVerifier != null)
                    checklist.VerifiedBy.Remove(currentLeadVerifier);
            }

            checklist.Assessors.Add(assessor);

            return Repository.Update(checklist);
        }
        public bool DeleteAssessor(Guid Id)
        {
            var assessor = assessorRepository.Get(Id);
            var checklist = Repository.GetCompleteChecklist(assessor.RigOapChecklistId.Value);

            var verifier = checklist.VerifiedBy.OrderBy(v => v.Order).FirstOrDefault(v => v.UserId == assessor.UserId);
            if (verifier != null)
                checklist.VerifiedBy.Remove(verifier);

            Repository.Update(checklist);
            return assessorRepository.Delete(Id);
        }
        public RigChecklistValidationResult ValidateChecklist(Guid rigOapChecklistId)
        {
            RigChecklistValidationResult validationResult = new RigChecklistValidationResult();
            var checklist = Repository.Get(rigOapChecklistId);

            if (checklist == null)
            {
                validationResult.AddError("Checklist not found");
                return validationResult;
            }

            ValidateChecklistPlanning(checklist, validationResult);
            ValidateChecklistAnswers(checklist, validationResult);

            return validationResult;
        }
        private void ValidateChecklistPlanning(RigOapChecklist checklist, RigChecklistValidationResult validationResult)
        {
            if (checklist.LocationId == 0)
                validationResult.AddError("Location cannot be empty");
            if (checklist.ChecklistDateTime == DateTime.MinValue)
                validationResult.AddError("Date cannot be empty");
            if (string.IsNullOrEmpty(checklist.Title))
                validationResult.AddError("Title cannot be empty");
            if (checklist.Assessors.Count(a => a.IsLead) == 0)
                validationResult.AddError("There must be at least one lead assessor");
        }
        private void ValidateChecklistAnswers(RigOapChecklist checklist, RigChecklistValidationResult validationResult)
        {
            if (checklist.Questions.Any(q => q.Answers.Any(a => string.IsNullOrEmpty(a.Value))))
                validationResult.AddError("All checklist questions must be answered");
        }
    }
}
