using Ensco.Irma.Models.Domain.Oap;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Data.Mappings
{
    public class DPAMapping : EntityTypeConfiguration<DPA>
    {
        public DPAMapping()
        {
            HasIndex(d => d.AssignedRigId);
        }
    }
}
