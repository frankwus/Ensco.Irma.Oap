using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ensco.Irma.Models.Domain.Oap.Audit;

namespace Ensco.Irma.Oap.Api.Corp.Models
{
    public class ProcessOapAuditWorkFlow
    {

        public ProcessOapAuditWorkFlow(Guid checklist, int user, OapAudit audit, string transition, string comment = "", int order = 0 )
        {
            Checklist = checklist;
            User = user;
            Transition = transition;
            Comment = comment;
            Order = order;
            Audit = audit;
        }

        public Guid Checklist { get; private set; }

        public int User { get; private set; }

        public string Transition { get; private set; }

        public string Comment { get; private set; }
        public int Order { get; set; }

        public OapAudit Audit { get; private set; }
    }
}