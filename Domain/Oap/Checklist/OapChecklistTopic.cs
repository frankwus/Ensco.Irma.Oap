using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapChecklistTopic : HistoricalEntityId<int>
    {
        [Column(Order = 5)]
        [StringLength(1024)]
        public string Description { get; set; }

        [Column(Order = 10, TypeName = "NVARCHAR")]
        [StringLength(1096)]
        public string Topic { get; set; }

        [Column(Order = 15)] 
        public int Order { get; set; }

        [Column(Order = 20)]
        [ForeignKey("OapChecklistGroup")]
        public int? OapChecklistGroupId { get; set; }

        [JsonIgnore]
        public OapChecklistGroup OapChecklistGroup { get; set; }

        [Column(Order = 25)]
        [ForeignKey("OapChecklistSubGroup")]
        public int OapChecklistSubGroupId { get; set; }

        [JsonIgnore]
        public OapChecklistSubGroup OapChecklistSubGroup { get; set; }

        [Column(Order = 30)]
        [InverseProperty("OapChecklistTopic")]
        public ICollection<OapChecklistQuestion> Questions { get; set; }
    }
}
