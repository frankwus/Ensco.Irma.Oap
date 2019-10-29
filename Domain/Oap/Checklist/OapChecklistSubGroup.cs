using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapChecklistSubGroup : HistoricalEntity<int>
    {
        [Column(Order = 5)]
        [StringLength(1024)]
        public string Description { get; set; }

        [Column(Order = 10)] 
        public int Order { get; set; }

        [Column(Order = 15)] 
        public bool IsVisible { get; set; }

        [Column(Order = 16)] 
        public bool IsPlantMonitoring { get; set; }

        [Column(Order = 17)] 
        public bool IsPlantMaintaining { get; set; }

        [Column(Order = 18)] 
        public bool IsWorkInstructions { get; set; }

        [Column(Order = 19)] 
        public bool IsThirdPartyActivities { get; set; } 

        [Column(Order = 20)]
        [ForeignKey("OapChecklistGroup")]
        public int OapChecklistGroupId { get; set; }

        [JsonIgnore]
        public OapChecklistGroup OapChecklistGroup { get; set; }

        [Column(Order = 25)]
        [InverseProperty("OapChecklistSubGroup")]
        public virtual ICollection<OapChecklistTopic> Topics { get; set; }
    }
}
