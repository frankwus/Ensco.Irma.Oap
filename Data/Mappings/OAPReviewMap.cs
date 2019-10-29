using Ensco.Irma.Models.Domain.IRMA;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Data.Mappings
{
    public class OAPReviewMap : EntityTypeConfiguration<IrmaReview>
    {
        public OAPReviewMap()
        {
            ToTable("OAP_Review");
        }
    }
}
