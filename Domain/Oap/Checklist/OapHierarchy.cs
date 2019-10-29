using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapHierarchy : HistoricalEntity<int>
    {
        [Column(Order = 4, TypeName = "NVARCHAR")]
        [Required]
        [StringLength(50)]
        public string Code { get; set; }


        [Column(Order = 5, TypeName = "NVARCHAR")]
        [StringLength(1024)]
        public string Description { get; set; }

        [Column(Order = 10)]
        public bool IsIsm { get; set; }

        [Column(Order = 15)]
        public bool IsProtocol { get; set; }

        [Column(Order = 20)]
        [ForeignKey("ChecklistLayout")]
        public int? ChecklistLayoutId { get; set; }

        [JsonIgnore]
        public OapChecklistLayout ChecklistLayout { get; set; }

        [Column(Order = 25)]
        [ForeignKey("ParentHierarchy")]
        public int? ParentHierarchyId { get; set; }

        public OapHierarchy ParentHierarchy { get; set; }

        [Column(Order = 30)]
        [InverseProperty("ParentHierarchy")]
        public virtual ICollection<OapHierarchy> ChildrenHierarchies { get; set; }

        

    }
}
