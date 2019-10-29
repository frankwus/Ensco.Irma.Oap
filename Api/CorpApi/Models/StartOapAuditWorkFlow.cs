using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ensco.Irma.Models.Domain.Oap.Audit;

namespace Ensco.Irma.Oap.Api.Corp.Models
{
    public class StartOapAuditWorkFlow
    {

        public StartOapAuditWorkFlow(Guid checklist, int owner, OapAudit audit)
        {
            Checklist = checklist;
            Owner = owner;
            Audit = audit;
        }

        public Guid Checklist { get; private set; }

        public int Owner { get; private set; }

        public OapAudit Audit { get; private set; }
    }
}