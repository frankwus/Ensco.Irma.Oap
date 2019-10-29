using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    using Newtonsoft.Json;

    public class RigOapChecklistGroupAsset : EntityId<Guid>
    {
        [Column(Order = 5)]
        [ForeignKey("RigOapChecklist")]
        public Guid RigOapChecklistId { get; set; }
       

        [JsonIgnore]
        public RigOapChecklist RigOapChecklist { get; set; }

        [Column(Order = 10)]
        [ForeignKey("Asset")]
        public int AssetId { get; set; }

        public OapAssetDataManagement Asset { get; set; }

        [Column(Order = 15)]
        public string Value { get; set; } 
    }
}
