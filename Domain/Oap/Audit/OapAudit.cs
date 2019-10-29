using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Models.Domain.Security;

namespace Ensco.Irma.Models.Domain.Oap.Audit
{
    public class OapAudit: HistoricalEntityId<int>
    {
        [Column(Order = 5)]
        [StringLength(1024)]
        [Required]
        public string Description { get; set; }

        [Column(Order = 10)]
        [StringLength(64)]
        [Required]
        public string AuditLevel { get; set; }

        [Column(Order = 15)]
        public bool IsCVT { get; set; }

        [Column(Order = 16)]
        public bool RepeatFinding { get; set; }

        [Column(Order = 17)]
        [StringLength(16)]
        public string Status { get; set; }

        [Column(Order = 18)]
        [StringLength(128)]
        public string AuditPurpose { get; set; }


        [Column(Order = 30)]
        [Required]
        public int RigId { get; set; }


        [Column(Order = 35)]
        [InverseProperty("AuditRights")]
        public virtual ICollection<OapAuditRight> OapAuditRights { get; set; }

        [Column(Order = 30)]
        [InverseProperty("AuditProtocols")]
        public virtual ICollection<OapAuditProtocol> OapAuditProtocols { get; set; }



    }

  
}
