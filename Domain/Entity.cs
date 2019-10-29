
using Ensco.Irma.Interfaces.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Ensco.Irma.Models.Domain
{
    //[DataContract]
    [Serializable]
    public abstract class Entity<T>: EntityId<T> , IEntity<T>
        where T:struct
    {
        [Column(Order = 2, TypeName = "NVARCHAR")]
        [StringLength(128)]
        [Required]
        public virtual string Name { get; set; }
         
    }
}
