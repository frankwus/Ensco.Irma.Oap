using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    /// <summary>
    /// This is applicable to protocols.  Check lists and protocols as entities are same. There names conveys
    /// different forms.
    /// </summary>
    public class OapProtocolQuestionHeader : HistoricalEntityId<int>
    {
        [Column(Order = 5, TypeName = "NVARCHAR")]
        [StringLength(1096)]
        public string Section { get; set; }
        
        [Column(Order = 510)]
        [StringLength(1024)]
        public string Description { get; set; }

        [Column(Order = 15)] 
        public int Criticality { get; set; }

        [Column(Order = 20)]
        [StringLength(128)]
        public string BasicCause { get; set; }

        [Column(Order = 25)]
        [ForeignKey("OapChecklistQuestion")]
        public int? OapChecklistQuestionId { get; set; }
         
        public OapChecklistQuestion OapChecklistQuestion { get; set; }

        [NotMapped]
        public int OapProtocolId
        {
            get { return OapChecklistQuestion?.OapChecklistTopic?.OapChecklistGroup?.OapChecklistId ?? 0; }
        }
    }
}
