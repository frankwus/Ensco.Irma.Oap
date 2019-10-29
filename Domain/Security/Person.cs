using Ensco.Irma.Models.Domain.Attributes;
using Ensco.Irma.Models.Domain.IRMA;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Security
{
    [NonOapEntity]
    [Table("Master_Users")]
    public class Person : IrmaEntity<int>
    {  
        [Column("PassPort", Order=5)]
        [StringLength(128)]
        public string Login { get; set; }

        [Column(Order = 10)]
        [StringLength(64)]
        public string FirstName { get; set; }

        [Column(Order = 15)]
        [StringLength(64)]
        public string LastName { get; set; }

        [Column(Order = 20,TypeName="NVARCHAR")]
        [DataType(DataType.Password)]
        [StringLength(128)]
        public string Password { get; set; }

        //[Column(Order = 25)]
        //public ICollection<PersonRole> Roles { get; set; }

        [Column("Position", Order = 30)] 
        public int? PositionId { get; set; }

        [Column("Department", Order = 35)] 
        public int? DepartmentId { get; set; }

        [Column(Order = 40)]
        [StringLength(128)]
        public string Email { get; set; }

        [Column("ADUser", Order = 45)] 
        public bool? IsADUser { get; set; }

        [Column("RigId", Order = 50)]
        public int RigId { get; set; }

        [Column("BusinessUnit", Order = 55)]
        public int? BusinessId { get; set; }

    }
}
