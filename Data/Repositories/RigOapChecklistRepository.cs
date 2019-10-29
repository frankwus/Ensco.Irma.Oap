
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    using System.Linq.Expressions;
    using Ensco.Irma.Data.Context;
    using Ensco.Irma.Interfaces.Data.Repositories;
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;

    public class RigOapChecklistRepository : BaseIdRepository<IrmaOapDbContext, RigOapChecklist, Guid>, IRigOapChecklistRepository
    {
        public RigOapChecklistRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        protected override IQueryable<RigOapChecklist> AllItems => Items.Include(c => c.OapChecklist).Include(ct => ct.OapChecklist.OapType).Include(cst => cst.OapChecklist.OapSubType);

        public IEnumerable<RigOapChecklist> GetAll(string status, DateTime checklistDate)
        {
            var results = Items.AsQueryable();

            if (!string.IsNullOrEmpty(status) && !status.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                if (status.Equals(ChecklistStatus.Open.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    results = (from c in results
                               where !c.Status.Equals(ChecklistStatus.Completed.ToString(), StringComparison.InvariantCultureIgnoreCase)                             
                               select c);
                }
                else
                {
                    results = (from c in results
                               where c.Status.Equals(status, StringComparison.InvariantCultureIgnoreCase)                              
                               select c);
                }
            }

            return (from c in results
                       where c.ChecklistDateTime >= checklistDate
                       && c.SiteId != "CORP"
                    select c).AsEnumerable();

            /*
            if (!string.IsNullOrEmpty(status) && status.Equals(ChecklistStatus.Open.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return Items.Where(ck => ck.ChecklistDateTime >= checklistDate && !ck.Status.Equals(ChecklistStatus.Completed.ToString(), StringComparison.InvariantCultureIgnoreCase));
            }

            return string.IsNullOrEmpty(status) ? Items.Where(ck => ck.ChecklistDateTime >= checklistDate) : Items.Where(ck => ck.ChecklistDateTime >= checklistDate && ck.Status.Equals(status, StringComparison.InvariantCultureIgnoreCase));
            */
        }

        public IEnumerable<RigOapChecklist> GetAll(string status)
        {
            if (!string.IsNullOrEmpty(status) && status.Equals(ChecklistStatus.Open.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return Items.Where(ck => !ck.Status.Equals(ChecklistStatus.Completed.ToString(), StringComparison.InvariantCultureIgnoreCase));
            }
            return status.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? GetAll() : Items.Where(ck => ck.Status.Equals(status, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<RigOapChecklist> GetByTypeSubType(string typeName, string subtypeName, string status)
        {
            if (typeName.Equals("All", StringComparison.InvariantCultureIgnoreCase) && subtypeName.Equals("All", StringComparison.InvariantCultureIgnoreCase) && status.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                return GetAll();
            }

            var result = AllItems;

            if (!string.IsNullOrEmpty(typeName) && !typeName.Equals("All"))
                result = AllItems.Where(c => c.OapChecklist.OapType.Name.Equals(typeName, StringComparison.InvariantCultureIgnoreCase));                

            if (!string.IsNullOrEmpty(subtypeName) && !subtypeName.Equals("All"))
                result = result.Where(c => c.OapChecklist.OapSubType.Name.Equals(subtypeName, StringComparison.InvariantCultureIgnoreCase));

            if (!string.IsNullOrEmpty(status) && !status.Equals("All"))
                result = result.Where(c => c.Status.Equals(status, StringComparison.InvariantCultureIgnoreCase));

            return result.ToList();

            //if (!string.IsNullOrEmpty(status) && status.Equals("Open", StringComparison.InvariantCultureIgnoreCase))
            //{
            //    return AllItems.Where(c => typeName.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapChecklist.OapType.Name.Equals(typeName, StringComparison.InvariantCultureIgnoreCase)
            //    && subtypeName.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapChecklist.OapSubType.Name.Equals(subtypeName, StringComparison.InvariantCultureIgnoreCase)
            //    && !c.Status.Equals("Closed", StringComparison.InvariantCultureIgnoreCase));
            //}
        }

        public IEnumerable<RigOapChecklist> GetByTypeSubTypeCode(string typeCode, string subtypeCode, string status)
        {
            if (typeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase) && subtypeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase) && status.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                return GetAll();
            }

            var results = AllItems.Where(c => c.SiteId != "CORP");

            if (!string.IsNullOrEmpty(typeCode) && !typeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                results = (from c in results
                           where c.OapChecklist.OapType.Code.Equals(typeCode, StringComparison.InvariantCultureIgnoreCase)                            
                           select c);
            }

            if (!string.IsNullOrEmpty(subtypeCode) && !subtypeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                results = (from c in results
                           where c.OapChecklist.OapSubType.Code.Equals(subtypeCode, StringComparison.InvariantCultureIgnoreCase)                          
                           select c);
            } 

            if (!string.IsNullOrEmpty(status) && !status.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                if (status.Equals(ChecklistStatus.Open.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    results = (from c in results
                               where !c.Status.Equals(ChecklistStatus.Completed.ToString(), StringComparison.InvariantCultureIgnoreCase)                            
                               select c);
                }
                else
                {
                    results = (from c in results
                               where c.Status.Equals(status, StringComparison.InvariantCultureIgnoreCase)                            
                               select c);
                }
            }

            return results.AsEnumerable();

            /*
            if (!string.IsNullOrEmpty(status) && status.Equals(ChecklistStatus.Open.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return AllItems.Where(c => typeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapChecklist.OapType.Code.Equals(typeCode, StringComparison.InvariantCultureIgnoreCase)
                && subtypeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapChecklist.OapSubType.Code.Equals(subtypeCode, StringComparison.InvariantCultureIgnoreCase)
                && !c.Status.Equals("Closed", StringComparison.InvariantCultureIgnoreCase));
            }

            return AllItems.Where(c => c.OapChecklist.OapType.Code.Equals(typeCode, StringComparison.InvariantCultureIgnoreCase)
            && subtypeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapChecklist.OapSubType.Code.Equals(subtypeCode, StringComparison.InvariantCultureIgnoreCase)
            && c.Status.Equals(status, StringComparison.InvariantCultureIgnoreCase));
            */
        }

        public IEnumerable<RigOapChecklist> GetByTypeSubTypeFormType(string typeName, string subtypeName, string formType, string status)
        {
            if (typeName.Equals("All", StringComparison.InvariantCultureIgnoreCase) && subtypeName.Equals("All", StringComparison.InvariantCultureIgnoreCase) && formType.Equals("All", StringComparison.InvariantCultureIgnoreCase) && status.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                return GetAll();
            } 

            var results = AllItems;

            if (!string.IsNullOrEmpty(typeName) && !typeName.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                results = (from c in results
                           where c.OapChecklist.OapType.Name.Equals(typeName, StringComparison.InvariantCultureIgnoreCase)
                           select c);
            }

            if (!string.IsNullOrEmpty(subtypeName) && !subtypeName.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                results = (from c in results
                           where c.OapChecklist.OapSubType.Name.Equals(subtypeName, StringComparison.InvariantCultureIgnoreCase)
                           select c);
            }

            if (!string.IsNullOrEmpty(formType) && !formType.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                results = (from c in results
                           where c.OapChecklist.OapProtocolFormType.Name.Equals(formType, StringComparison.InvariantCultureIgnoreCase)
                           select c);
            } 

            if (!string.IsNullOrEmpty(status) && !status.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                if (status.Equals(ChecklistStatus.Open.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    results = (from c in results
                               where !c.Status.Equals(ChecklistStatus.Completed.ToString(), StringComparison.InvariantCultureIgnoreCase)
                               select c);
                }
                else
                {
                    results = (from c in results
                               where c.Status.Equals(status, StringComparison.InvariantCultureIgnoreCase)
                               select c);
                }
            }

            return results.AsEnumerable();

            /*
            if (!string.IsNullOrEmpty(status) && status.Equals(ChecklistStatus.Open.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return AllItems.Where(c => typeName.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapChecklist.OapType.Name.Equals(typeName, StringComparison.InvariantCultureIgnoreCase)
                && subtypeName.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapChecklist.OapSubType.Name.Equals(subtypeName, StringComparison.InvariantCultureIgnoreCase)
                && formType.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapChecklist.OapProtocolFormType.Name.Equals(formType, StringComparison.InvariantCultureIgnoreCase)
                && !c.Status.Equals("Closed", StringComparison.InvariantCultureIgnoreCase));
            }

            return AllItems.Where(c => c.OapChecklist.OapType.Name.Equals(typeName, StringComparison.InvariantCultureIgnoreCase)
                && subtypeName.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapChecklist.OapSubType.Name.Equals(subtypeName, StringComparison.InvariantCultureIgnoreCase)
                && formType.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapChecklist.OapProtocolFormType.Name.Equals(formType, StringComparison.InvariantCultureIgnoreCase)
                && status.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.Status.Equals(status, StringComparison.InvariantCultureIgnoreCase));
            */
        }

        public IEnumerable<RigOapChecklist> GetByTypeSubTypeCodeFormType(string typeCode, string subtypeCode, string formType, string status)
        {
            if (typeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase) && subtypeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase) && formType.Equals("All", StringComparison.InvariantCultureIgnoreCase) && status.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                return GetAll();
            }

            var results = AllItems;            

            if (!string.IsNullOrEmpty(typeCode) && !typeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                results = (from c in results
                           where c.OapChecklist.OapType.Code.Equals(typeCode, StringComparison.InvariantCultureIgnoreCase)
                           select c);
            } 

            if (!string.IsNullOrEmpty(subtypeCode) && !subtypeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                results = (from c in results
                           where c.OapChecklist.OapSubType.Code.Equals(subtypeCode, StringComparison.InvariantCultureIgnoreCase)
                           select c);
            }

            if (!string.IsNullOrEmpty(formType) && !formType.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                results = (from c in results
                           where c.OapChecklist.OapProtocolFormType.Name.Equals(formType, StringComparison.InvariantCultureIgnoreCase)
                           select c);
            }

            if (!string.IsNullOrEmpty(status) && !status.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                if (status.Equals(ChecklistStatus.Open.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    results = (from c in results
                               where !c.Status.Equals(ChecklistStatus.Completed.ToString(), StringComparison.InvariantCultureIgnoreCase)
                               select c);
                }
                else
                {
                    results = (from c in results
                               where c.Status.Equals(status, StringComparison.InvariantCultureIgnoreCase)
                               select c);
                }
            }

            return results.AsEnumerable();
             
            /*
            if (!string.IsNullOrEmpty(status ?? "All") && status.Equals(ChecklistStatus.Open.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                if (!formType.Equals("All", StringComparison.InvariantCultureIgnoreCase))
                {
                    return AllItems.Where(c => c.OapChecklist.OapProtocolFormType.Name.Equals(formType, StringComparison.InvariantCultureIgnoreCase) && !c.Status.Equals("Closed", StringComparison.InvariantCultureIgnoreCase)
                    && (typeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapChecklist.OapType.Code.Equals(typeCode, StringComparison.InvariantCultureIgnoreCase)
                    && subtypeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapChecklist.OapSubType.Code.Equals(subtypeCode, StringComparison.InvariantCultureIgnoreCase)));
                }
                return GetByTypeSubTypeCode(typeCode, subtypeCode, status);
            }

            if (!formType.Equals("All", StringComparison.InvariantCultureIgnoreCase))
            {
                return AllItems.Where(c => c.OapChecklist.OapProtocolFormType.Name.Equals(formType, StringComparison.InvariantCultureIgnoreCase)
                    && ((typeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapChecklist.OapType.Code.Equals(typeCode, StringComparison.InvariantCultureIgnoreCase))
                    && (subtypeCode.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.OapChecklist.OapSubType.Code.Equals(subtypeCode, StringComparison.InvariantCultureIgnoreCase))
                    && (status.Equals("All", StringComparison.InvariantCultureIgnoreCase) ? true : c.Status.Equals(status, StringComparison.InvariantCultureIgnoreCase))));
            }
            */
            //return GetByTypeSubTypeCode(typeCode, subtypeCode, status);
        }

        public RigOapChecklist GetByUniqueId(int uniqueId)
        {
            return Items.Where(c => c.RigChecklistUniqueId == uniqueId).FirstOrDefault();
        }

        public RigOapChecklist GetCompleteChecklist(Guid rigCheckListId)
        {
            return (from it in Items.Include(c => c.OapChecklist)
                                    .Include(ct => ct.OapChecklist.OapType)
                                    .Include(cst => cst.OapChecklist.OapSubType)
                                    .Include(c => c.Assets)
                                    .Include(c => c.Comments)
                                    .Include(c => c.Questions.Select(a => a.Answers))
                                    .Include(c => c.Questions.Select(q => q.Findings))
                                    .Include(c => c.Questions.Select(q => q.OapChecklistQuestion))
                                    .Include(c => c.OapChecklist.Comments)
                                    .Include(c => c.OapChecklist.Groups)
                                    .Include(c => c.OapChecklist.Groups.Select(g => g.OapGraphic))
                                    .Include(c => c.OapChecklist.Groups.Select(g => g.SubGroups.Select(sg => sg.Topics.Select(st => st.Questions.Select(q => q.OapChecklistQuestionDataType)))))
                                    .Include(c => c.OapChecklist.Groups.Select(g => g.SubGroups.Select(sg => sg.Topics.Select(st => st.Questions.Select(q => q.OapFrequency)))))
                    where it.Id == rigCheckListId
                    select it).FirstOrDefault();
        }

        public IEnumerable<RigOapChecklist> GetFsoChecklistByMinDate(DateTime minDate, int oapChecklistId)
        {
            return Items.Where(c => c.OapchecklistId == oapChecklistId && c.ChecklistDateTime >= minDate);
        }

        public IEnumerable<RigOapChecklist> GetOpenFsoChecklist(int fsoChecklistId)
        {
            return Items.Where(it => it.OapchecklistId == fsoChecklistId && (it.Status == ChecklistStatus.Open.ToString() || it.Status == ChecklistStatus.Pending.ToString()));
        }

        //public IEnumerable<RigOapChecklist> GetRelatedQuestionSearch(int questionId, DateTime fromDate, DateTime toDate)
        //{
        //    return from it in AllItems.Include(ct => ct.OapChecklist)
        //                              .Include(c => c.OapChecklist.OapType) //protocol
        //                              .Include(c => c.Questions.Select(a => a.Answers))
        //                              .Include(c => c.OapChecklist.Groups) //category  
        //                              .Include(c => c.OapChecklist.Groups.Select(g => g.SubGroups.Select(sg => sg.Topics.Select(st => st.Questions)))) //topics
        //                              .Include(c => c.Questions.Select(q => q.Findings))
        //           where it.Questions.Any(rq => rq.OapChecklistQuestionId == questionId) && it.ChecklistDateTime >= fromDate && it.ChecklistDateTime <= toDate
        //           select it;
        //}

        public RigOapChecklist GetLastChecklistWithQuestions(int checklistId, DateTime currentChecklistDate)
        {
            return (from it in AllItems.Include(ct => ct.Questions)
                    where it.ChecklistDateTime <= currentChecklistDate 
                          && it.OapchecklistId == checklistId
                            && (!it.Status.Equals(ChecklistStatus.Completed.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    orderby it.ChecklistDateTime descending
                    select it).FirstOrDefault(); 
        }

        public IEnumerable<RigOapChecklist> GetGetAllActiveChecklistsWithNoQuestions(int checklistId)
        {
            var results = AllItems.Include(ct => ct.Questions); 

            return (from it in results
                    where  it.OapchecklistId == checklistId
                            && (!it.Status.Equals(ChecklistStatus.Completed.ToString(), StringComparison.InvariantCultureIgnoreCase)) 
                            && it.Questions.Any( q => q.Answers.Any(a => !string.IsNullOrEmpty(a.Value) && a.Value == "N"))
                    select it).AsEnumerable();
        }

        public IQueryable<RigOapChecklist> GetQueryable(Expression<Func<RigOapChecklist, bool>> expression)
        {
            return
                AllItems
                    .Include(ct => ct.OapChecklist.OapType)
                    .Include(cst => cst.OapChecklist.OapSubType)
                    .Include(c => c.Assets)
                    .Include(c => c.Comments)
                    .Include(c => c.Questions.Select(a => a.Answers))
                    .Include(c => c.Questions.Select(q => q.Findings))
                    .Include(c => c.Questions.Select(q => q.OapChecklistQuestion))
                    .Include(c => c.OapChecklist.Comments)
                    .Include(c => c.OapChecklist.Groups)
                    .Include(c => c.OapChecklist.Groups.Select(g => g.OapGraphic))
                    .Include(c => c.OapChecklist.Groups.Select(g => g.SubGroups.Select(sg => sg.Topics.Select(st => st.Questions.Select(q => q.OapChecklistQuestionDataType)))))
                    .Include(c => c.OapChecklist.Groups.Select(g => g.SubGroups.Select(sg => sg.Topics.Select(st => st.Questions.Select(q => q.OapFrequency)))))
                    .Where(expression);
        }

        public IEnumerable<RigOapChecklist> GetAllChecklistsByChecklistId( int checklistId, DateTime fromDate, DateTime toDate)
        {
            return from it in AllItems.Include(ct => ct.OapChecklist)
                                      //.Include(c => c.OapChecklist.OapType) //protocol
                                      //.Include(c => c.Questions.Select(a => a.Answers))
                                      //.Include(c => c.OapChecklist.Groups) //category  
                                      //.Include(c => c.OapChecklist.Groups.Select(g => g.SubGroups.Select(sg => sg.Topics.Select(st => st.Questions)))) //topics
                                      //.Include(c => c.Questions.Select(q => q.Findings))
                   where it.OapChecklist.Id  == checklistId && it.ChecklistDateTime >= fromDate && it.ChecklistDateTime <= toDate
                   select it;
        }
    }
}
