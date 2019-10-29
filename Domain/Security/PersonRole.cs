using Ensco.Irma.Models.Domain.Attributes;
using Ensco.Irma.Models.Domain.IRMA;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Security
{
    [NonOapEntity]
    public class PersonRole: IrmaEntity<int> 
    {
        [Column(Order = 5)]
        [ForeignKey("Person")]
        public int PersonId { get; set; }

        [JsonIgnore]
        public Person Person { get; set; }

        [Column(Order =10)]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
