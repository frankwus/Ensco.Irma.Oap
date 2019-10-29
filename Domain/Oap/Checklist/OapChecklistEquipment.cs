using Ensco.Irma.Models.Domain.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapChecklistEquipment : HistoricalEntityId<int>
    {

        [Column(Order = 5)]
        [SqlDefaultValue("dbo.fn_GetRigId()")]
        public string RigId { get; set; }


        [Column(Order = 10)]
        [ForeignKey("OapChecklist")]
        public int OapChecklistId { get; set; }

        [JsonIgnore]
        public OapChecklist OapChecklist { get; set; }

        [Column(Order = 15)]
        [ForeignKey("OapEquipment")]
        public int OapEquipmentId { get; set; }

        [JsonIgnore]
        public OapEquipment OapEquipment { get; set; }

        [Column(Order = 20)]
        [StringLength(1092)]
        [Required]
        public string Description { get; set; }

        [Column(Order = 25)]
        [Required]
        public int Order { get; set; }

    }  
}
