
using Ensco.Irma.Interfaces.Domain;
using Ensco.Irma.Models.Domain.Attributes;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Ensco.Irma.Models.Domain
{
    [Serializable]
    public abstract class EntityId<T> : IEntityId<T>
        where T : struct
    {

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual T Id { get; set; } 

        [Column(Order = 1000, TypeName = "datetime2")]
        public virtual DateTime CreatedDateTime { get; set; }

        [Column(Order = 1001, TypeName = "datetime2")]
        public virtual DateTime UpdatedDateTime { get; set; }

        [Column(Order = 1002, TypeName = "NVARCHAR")]
        [StringLength(128)]
        public virtual string UpdatedBy { get; set; }

        [Column(Order = 1003, TypeName = "NVARCHAR")]
        [StringLength(128)]
        public virtual string CreatedBy { get; set; }

        [Column(Order = 1004, TypeName = "NCHAR")]
        [StringLength(10)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [SqlDefaultValue("dbo.fn_GetSiteId()")]
        public virtual string SiteId { get; set; }
    }
}
