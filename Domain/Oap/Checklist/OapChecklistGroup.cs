using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapChecklistGroup : HistoricalEntity<int>
    {
        [Column(Order = 5)]
        [StringLength(1024)]
        public string Description { get; set; }

        [Column(Order = 10)] 
        public int Order { get; set; }

        [Column(Order = 15)]
        [ForeignKey("OapGraphic")]
        public int? OapGraphicId { get; set; }

        public OapGraphic OapGraphic { get; set; }

        [Column(Order = 20)]
        [ForeignKey("OapChecklist")]
        public int OapChecklistId { get; set; }

        [JsonIgnore]
        public OapChecklist OapChecklist { get; set; }

        [Column(Order = 25)]
        [InverseProperty("OapChecklistGroup")]
        public virtual ICollection<OapChecklistSubGroup> SubGroups { get; set; }

        [Column(Order = 35)]
        [InverseProperty("OapChecklistGroup")]
        public virtual ICollection<OapAssetDataManagement> Assets { get; set; } 
        
    }
}
