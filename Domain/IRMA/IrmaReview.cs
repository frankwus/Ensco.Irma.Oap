using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Models.Domain.IRMA
{
    public class IrmaReview : IrmaEntityId<int>
    {        
        public int? RigId { get; set; }
        public string SourceForm { get; set; }
        public string SourceFormId { get; set; }
        public int ReviewerPassportId { get; set; }        
        public string Comment { get; set; }
        public int? SourceBU { get; set; }
        public int RequestedBy { get; set; }
    }
}
