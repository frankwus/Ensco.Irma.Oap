using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Models.Domain.IRMA
{
    //[Table("vw_AdminCustom")] This is being handled in EF mapping
    public class AdminCustom : Entity<int>
    {
        public override int Id {get; set;}

        public virtual string Value { get; set; }

        [NotMapped]
        public override DateTime CreatedDateTime { get; set; }

        [NotMapped]
        public override DateTime UpdatedDateTime { get; set; }

        [NotMapped]
        public override string UpdatedBy { get; set; }

        [NotMapped]
        public override string CreatedBy { get; set; }

        [NotMapped]
        public override string SiteId { get; set; }
    }
}
