using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapChecklistQuestion : HistoricalEntityId<int>
    {
        [Column(Order = 5)]
        [StringLength(1024)]
        public string Description { get; set; }

        [Column(Order = 10, TypeName = "NVARCHAR")]
        [StringLength(4000)]
        public string Question { get; set; }

        [Column(Order = 15)]
        [ForeignKey("OapChecklistTopic")]
        public int OapChecklistTopicId { get; set; }

        [JsonIgnore]
        public OapChecklistTopic OapChecklistTopic { get; set; }

        [Column(Order = 20)]
        [StringLength(16)]
        public string Order { get; set; }

        //[Column(Order = 4)]
        //[ForeignKey("OapCulture")]
        //public int? OapCultureId { get; set; }

        //public OapCulture OapCulture { get; set; }

        [Column(Order = 25)] 
        [Required]
        public float Weight { get; set; }

        [Required]
        [Column(Order = 30)] 
        public int Maximum { get; set; }

        [Column(Order = 35)]        
        public int YesValue { get; set; }

        [Column(Order = 40)]       
        public bool EditNoValue { get; set; }

        [Column(Order = 41)]
        [StringLength(128)]
        public string Section { get; set; }

        [Column(Order = 42)] 
        public int? Criticality { get; set; }

        [Column(Order = 43)]
        [StringLength(128)]
        public string BasicCauseClassification { get; set; }

        [Column(Order = 45)] 
        public bool Randomize { get; set; } 

        [Column(Order = 47)]
        [ForeignKey("OapFrequency")]
        public int? OapFrequencyId { get; set; }
         
        public OapFrequency OapFrequency { get; set; }

        [Column(Order = 48)]
        [ForeignKey("OapChecklistQuestionDataType")]
        public int? OapChecklistQuestionDataTypeId { get; set; }

        public OapChecklistQuestionDataType OapChecklistQuestionDataType { get; set; }

        [Column(Order = 50)]
        [InverseProperty("OapChecklistQuestion")]
        public virtual ICollection<OapProtocolQuestionHeader> ProtocolQuestionHeader { get; set; }

        [Column(Order = 55, TypeName = "NVARCHAR")]
        [StringLength(4000)]
        public string Help { get; set; }

        [Column(Order = 60, TypeName = "NVARCHAR")]
        [StringLength(1024)]
        public string Comment { get; set; }
         
        [Column(Order = 70)]
        [InverseProperty("OapChecklistQuestion")]
        public virtual ICollection<OapChecklistQuestionTagMap> OapChecklistQuestionTagMaps { get; set; }

        [Column(Order = 80)]
        [InverseProperty("OapChecklistQuestion")]
        public virtual ICollection<OapCheckListQuestionRelatedQuestionMap> OapChecklistRelatedQuestionMaps { get; set; }

        [Column(Order = 90)]        
        public virtual ICollection<RigOapChecklistQuestionNoAnswerComment> NoAnswers { get; set; }

    }
}
