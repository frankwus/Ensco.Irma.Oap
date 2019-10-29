using Ensco.Irma.Models.Domain.Attributes;
using Ensco.Irma.Models.Domain.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapChecklistReviewer : HistoricalEntityId<int>
    {
        [Column(Order = 10)]
        [ForeignKey("OapChecklist")]
        public int OapChecklistId { get; set; }

        [JsonIgnore]
        public OapChecklist OapChecklist { get; set; }

        [Column(Order = 15)]
        public int ReviewerPositionId { get; set; }

        [Column(Order = 20)]
        [SqlDefaultValue("dbo.fn_GetRigId()")]
        public string RigId { get; set; }

        [Column(Order = 25)]
        public bool IsGlobal { get; set; }

        [Column(Order = 30)]
        public int BusinessUnitId { get; set; }

    }
}
