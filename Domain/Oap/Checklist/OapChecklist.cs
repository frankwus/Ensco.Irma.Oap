using Ensco.Irma.Models.Domain.Security;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapChecklist : HistoricalEntity<int>
    {
        [Column(Order = 5)]
        [StringLength(1024)]
        [Required]
        public string Description { get; set; }

        [Column(Order = 10)]
        [StringLength(64)]
        [Required]
        public string ControlNumber { get; set; }

        [Column(Order = 15)]
        public bool Randomize { get; set; }

        [Column(Order = 20)]
        [ForeignKey("OapType")]
        public int OapTypeId { get; set; }
        
        public OapHierarchy OapType { get; set; }

        [Column(Order = 25)]
        [ForeignKey("OapSubType")]
        public int? OapSubTypeId { get; set; }

        public OapHierarchy OapSubType { get; set; }

        [Column(Order = 30)]
        [ForeignKey("OapProtocolFormType")]
        public int OapProtocolFormTypeId { get; set; }

        public OapProtocolFormType OapProtocolFormType { get; set; }

        [Column(Order = 35)]
        [ForeignKey("OapFrequencyType")]
        public int OapFrequencyTypeId { get; set; }

        public OapFrequencyType OapFrequencyType { get; set; }

        [Column(Order = 40)]
        public ICollection<OapChecklistGroup> Groups { get; set; }

        [Column(Order = 45)]
        public ICollection<OapChecklistComment> Comments { get; set; }

        [Column(Order = 50,TypeName ="NVARCHAR")]        
        public string Help { get; set; }

       
    }
}
