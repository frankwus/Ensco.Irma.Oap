using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    using Newtonsoft.Json;

    public class RigOapChecklistThirdPartyJob : EntityId<Guid>
    {
        [Column(Order = 5)]
        [ForeignKey("RigOapChecklist")]
        public Guid RigOapChecklistId { get; set; }

        [JsonIgnore]
        public RigOapChecklist RigOapChecklist { get; set; }

        [Column(Order = 10)] 
        public int JodId { get; set; }         


        [Column(Order = 20)]
        public int ThirdPartyCount { get; set; }
    }
}
