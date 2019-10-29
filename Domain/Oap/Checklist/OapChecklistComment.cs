using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    /// <summary>
    /// Name represets the Comment box type exampel ThirdPartyActivities/Comments etc
    /// </summary>
    public class OapChecklistComment : HistoricalEntityId<int>
    {
        [Column(Order = 5)]
        [StringLength(1024)]
        public string Description { get; set; }

        [Column(Order = 10)]
        [ForeignKey("OapChecklist")]
        public int OapChecklistId { get; set; }

        [JsonIgnore]
        public OapChecklist OapChecklist { get; set; }

        [Column(Order = 15)]
        public int Order { get; set; }

        [Column(Order = 20, TypeName = "NVARCHAR")]
        [StringLength(1024)]
        public string Question { get; set; }

        [Column(Order = 25)]
        [StringLength(1024)]
        public string SubQuestion { get; set; }
    }
}
