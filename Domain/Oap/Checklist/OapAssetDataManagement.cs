using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapAssetDataManagement : EntityId<int>
    {
        [Column(Order = 5)]
        [ForeignKey("OapChecklistGroup")]
        public int OapChecklistGroupId { get; set; }

        [JsonIgnore]
        public OapChecklistGroup OapChecklistGroup { get; set; }

        [Column(Order = 15)]
        [ForeignKey("OapSubSystem")]
        public int OapSubSystemId { get; set; }
         
        public OapSubSystem OapSubSystem { get; set; }

        [Column(Order = 20)]
        [StringLength(1092)]
        [Required]
        public string Description { get; set; }


        [Column(Order = 25)] 
        [Required]
        public int Order { get; set; }


        [Column(Order = 30)] 
        public bool SafetyCritical { get; set; }

        [Column(Order = 35)]
        public bool OperationalCritical { get; set; }


        [Column(Order = 40)]
        public bool ClientCritical { get; set; }


        [Column(Order = 45)]
        public bool EnvironmentalCritical { get; set; }


        [Column(Order = 50)]
        public bool NonCritical { get; set; }


        [Column(Order = 55)]
        public bool ACritical { get; set; }

        [Column(Order = 60)]
        [StringLength(128)]
        [Required]
        public string ReferenceId { get; set; }

        [NotMapped]
        public OapSystemGroup SystemGroup { get; set; }

        [NotMapped]
        public OapSystemGroup System { get; set; }


    }
}
