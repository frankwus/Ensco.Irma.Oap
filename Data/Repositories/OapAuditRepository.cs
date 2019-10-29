using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Audit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ensco.Irma.Data.Repositories
{
    public class OapAuditRepository: HistoricalBaseIdRepository<IrmaOapDbContext, OapAudit, int>, IOapAuditRepository
    {

        public OapAuditRepository(IIrmaOapDbContext context, ILog log) : base((IrmaOapDbContext)context, log)
        {

        }

        public IEnumerable<OapAudit> GetAllByStatus(string status)
        {
            if (status.Equals("Open", StringComparison.InvariantCultureIgnoreCase))
            {
                return GetAll();
            }

            return AllItems.Where(c =>c.Status.Equals(status, StringComparison.InvariantCultureIgnoreCase)
                );
        }

        public OapAudit GetCompleteAudit(int auditId)
        {
            return (from it in AllItems.Include(a => a.OapAuditProtocols.Select(p => p.RigOapChecklist))                     
                                       .Include(a => a.OapAuditProtocols.Select(p => p.RigOapChecklist.OapChecklist.OapType))
                                       //.Include(a => a.OapAuditProtocols.Select(p => p.RigOapChecklist.OapChecklist.OapSubType))
                                       //.Include(a => a.OapAuditProtocols.Select(p => p.RigOapChecklist.Assessors))
                                       //.Include(a => a.OapAuditProtocols.Select(p => p.RigOapChecklist.Assets))
                                       //.Include(a => a.OapAuditProtocols.Select(p => p.RigOapChecklist.Comments))
                                       //.Include(a => a.OapAuditProtocols.Select(p => p.RigOapChecklist.Questions.Select(ans => ans.Answers)))
                                       //.Include(a => a.OapAuditProtocols.Select(p => p.RigOapChecklist.Questions.Select(q => q.Findings)))
                                       //.Include(a => a.OapAuditProtocols.Select(p => p.RigOapChecklist.Questions.Select(q => q.OapChecklistQuestion)))
                                       //.Include(a => a.OapAuditProtocols.Select(p => p.RigOapChecklist.OapChecklist.Comments))
                                       //.Include(a => a.OapAuditProtocols.Select(p => p.RigOapChecklist.OapChecklist.Groups))
                                       //.Include(a => a.OapAuditProtocols.Select(p => p.RigOapChecklist.OapChecklist.Groups.Select(g => g.OapGraphic)))
                                       //.Include(a => a.OapAuditProtocols.Select(p => p.RigOapChecklist.OapChecklist.Groups.Select(g => g.SubGroups.Select(sg => sg.Topics.Select(st => st.Questions.Select(q => q.OapChecklistQuestionDataType))))))
                                       //.Include(a => a.OapAuditProtocols.Select(p => p.RigOapChecklist.OapChecklist.Groups.Select(g => g.SubGroups.Select(sg => sg.Topics.Select(st => st.Questions.Select(q => q.OapFrequency))))))
                    where it.Id == auditId
                    select it).FirstOrDefault();
        }
    }
}
