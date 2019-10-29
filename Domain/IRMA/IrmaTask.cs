using Ensco.Irma.Models.Domain.Security;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.IRMA
{
    public  class IrmaTask: IrmaEntityId<int>
    {
        [Column(Order = 5,TypeName = "VARCHAR")]
        [StringLength(100)]
        [Required]
        public virtual string Source { get; set; }

        [Column(Order = 10)]  
        public virtual string SourceId { get; set; }

        [Column(Order = 15)]
        [StringLength(2048)]
        public virtual string SourceUrl { get; set; }

        [Column(Order = 20)]
        public virtual string Comment { get; set; }

        [Column(Order = 25)]
        [ForeignKey("Assignee")]
        public virtual int AssigneeId { get; set; }

        public virtual Person Assignee { get; set; }

        [Column(Order = 30, TypeName = "datetime2")] 

        public virtual DateTime? DueDate { get; set; }

        [Column(Order = 35, TypeName = "datetimeoffset")]
        public virtual DateTimeOffset? AssignedDateTime { get; set; }

        [Column(Order = 40)]
        public virtual int AssignedBy { get; set; }

        [Column(Order = 45)]
        [Required]
        public virtual string Status { get; set; }
    }
}
