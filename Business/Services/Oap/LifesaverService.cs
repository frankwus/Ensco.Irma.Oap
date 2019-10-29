using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Models.Domain.Oap.Checklist.Lifesaver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Services.Oap
{
    public class LifesaverService : ILifesaverService
    {
        private readonly IRigOapChecklistService rigOapChecklistService;
        private readonly IOapChecklistService oapChecklistService;

        public LifesaverService(IRigOapChecklistService rigOapChecklistService, IOapChecklistService oapChecklistService)
        {
            this.rigOapChecklistService = rigOapChecklistService;
            this.oapChecklistService = oapChecklistService;
        }

        public LifesaverCompliance GetComplianceStatus()
        {
            LifesaverCompliance complianceModel = new LifesaverCompliance();
            var _14daysAgo = DateTime.Now.Date.AddDays(-14);

            IEnumerable<RigOapChecklist> lifeSaverChecklists = rigOapChecklistService.GetByTypeSubType("Life Savers", "All", "All");
            lifeSaverChecklists = lifeSaverChecklists.OrderBy(c => c.ChecklistDateTime);

            
            foreach (var checklist in lifeSaverChecklists)
            {

                foreach (var question in checklist.Questions)
                {
                    if (question.OapChecklistQuestion == null || question.Answers == null)
                        continue;

                    foreach (var answer in question.Answers)
                    {
                        if ((answer.Value == "Y" || answer.Value == "N") && question.OapChecklistQuestion.Description.ToUpperInvariant().Contains("CM"))
                        {
                            complianceModel.CM = checklist.ChecklistDateTime < _14daysAgo ? false : true;
                            if (!complianceModel.LastCMDate.HasValue || complianceModel.LastCMDate < checklist.ChecklistDateTime)
                                complianceModel.LastCMDate = checklist.ChecklistDateTime;                            
                        }

                        if ((answer.Value == "Y" || answer.Value == "N") && question.OapChecklistQuestion.Description.ToUpperInvariant().Contains("CS"))
                        {
                            complianceModel.CSE = checklist.ChecklistDateTime < _14daysAgo ? false : true;
                            if (!complianceModel.LastCSEDate.HasValue || complianceModel.LastCSEDate < checklist.ChecklistDateTime)
                                complianceModel.LastCSEDate = checklist.ChecklistDateTime;                            
                        }

                        if ((answer.Value == "Y" || answer.Value == "N") && question.OapChecklistQuestion.Description.ToUpperInvariant().Contains("DO"))
                        {
                            complianceModel.DO = checklist.ChecklistDateTime < _14daysAgo ? false : true;
                            if (!complianceModel.LastDODate.HasValue || complianceModel.LastDODate < checklist.ChecklistDateTime)
                                complianceModel.LastDODate = checklist.ChecklistDateTime;                            
                        }

                        if ((answer.Value == "Y" || answer.Value == "N") && question.OapChecklistQuestion.Description.ToUpperInvariant().Contains("EI"))
                        {
                            complianceModel.EI = checklist.ChecklistDateTime < _14daysAgo ? false : true;
                            if (!complianceModel.LastEIDate.HasValue || complianceModel.LastEIDate < checklist.ChecklistDateTime)
                                complianceModel.LastEIDate = checklist.ChecklistDateTime;                            
                        }

                        if ((answer.Value == "Y" || answer.Value == "N") && question.OapChecklistQuestion.Description.ToUpperInvariant().Contains("JSA"))
                        {
                            complianceModel.JSA = checklist.ChecklistDateTime < _14daysAgo ? false : true;
                            if (!complianceModel.LastJSADate.HasValue || complianceModel.LastJSADate < checklist.ChecklistDateTime)
                                complianceModel.LastJSADate = checklist.ChecklistDateTime;                            
                        }

                        if ((answer.Value == "Y" || answer.Value == "N") && question.OapChecklistQuestion.Description.ToUpperInvariant().Contains("LO"))
                        {
                            complianceModel.LO = checklist.ChecklistDateTime < _14daysAgo ? false : true;
                            if (!complianceModel.LastLODate.HasValue || complianceModel.LastLODate < checklist.ChecklistDateTime)
                                complianceModel.LastLODate = checklist.ChecklistDateTime;                            
                        }

                        if ((answer.Value == "Y" || answer.Value == "N") && question.OapChecklistQuestion.Description.ToUpperInvariant().Contains("PTW"))
                        {
                            complianceModel.PTW = checklist.ChecklistDateTime < _14daysAgo ? false : true;
                            if (!complianceModel.LastPTWDate.HasValue || complianceModel.LastPTWDate < checklist.ChecklistDateTime)
                                complianceModel.LastPTWDate = checklist.ChecklistDateTime;                            
                        }


                        if ((answer.Value == "Y" || answer.Value == "N") && question.OapChecklistQuestion.Description.ToUpperInvariant().Contains("PS"))
                        {
                            complianceModel.PS = checklist.ChecklistDateTime < _14daysAgo ? false : true;
                            if (!complianceModel.LastPSDate.HasValue || complianceModel.LastPSDate < checklist.ChecklistDateTime)
                                complianceModel.LastPSDate = checklist.ChecklistDateTime;                            
                        }

                        if ((answer.Value == "Y" || answer.Value == "N") && question.OapChecklistQuestion.Description.ToUpperInvariant().Contains("SWA"))
                        {
                            complianceModel.SWA = checklist.ChecklistDateTime < _14daysAgo ? false : true;
                            if (!complianceModel.LastSWADate.HasValue || complianceModel.LastSWADate < checklist.ChecklistDateTime)
                                complianceModel.LastSWADate = checklist.ChecklistDateTime;                            
                        }

                        if ((answer.Value == "Y" || answer.Value == "N") && question.OapChecklistQuestion.Description.ToUpperInvariant().Contains("WH"))
                        {
                            complianceModel.WH = checklist.ChecklistDateTime < _14daysAgo ? false : true;
                            if (!complianceModel.LastWHDate.HasValue || complianceModel.LastWHDate < checklist.ChecklistDateTime)
                                complianceModel.LastWHDate = checklist.ChecklistDateTime;                            
                        }

                    }
                }
            }


            return complianceModel;
        }

    }
}
