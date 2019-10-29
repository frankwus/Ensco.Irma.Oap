
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Models.Domain.Oap.Audit
{
    public class OapAuditProtocol: EntityId<int>
    {

        [Column(Order = 5)]
        [ForeignKey("AuditProtocols")]
        public int AuditId { get; set; }

        [JsonIgnore]
        public OapAudit AuditProtocols { get; set; }

        [Column(Order = 10)]
        [ForeignKey("RigOapChecklist")]
        public Guid RigOapCheckListId { get; set; }
       
        public RigOapChecklist RigOapChecklist { get; set; }
    }
}
