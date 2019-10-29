using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ensco.Irma.Models.Domain.Security;
using Newtonsoft.Json;

namespace Ensco.Irma.Models.Domain.Oap.Audit
{
    public class OapAuditRight:EntityId<int>
    {
        [Column(Order = 2)]
        [ForeignKey("AuditRights")]
        public int AuditId { get; set; }
        [JsonIgnore]
        public OapAudit AuditRights { get; set; }

        [Column(Order = 5)]
       
        public int UserId { get; set; }

        [Column(Order = 6)]
        public  bool Edit { get; set; }

        [Column(Order = 8)]
        public bool ReadOnly { get; set; }

        
    }
}
