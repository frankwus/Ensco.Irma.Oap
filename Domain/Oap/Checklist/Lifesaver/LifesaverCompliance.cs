using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Models.Domain.Oap.Checklist.Lifesaver
{
    public class LifesaverCompliance
    {
        public bool CSE { get; set; } = false;
        public DateTime? LastCSEDate { get; set; }
        public bool DO { get; set; } = false;
        public DateTime? LastDODate { get; set; }
        public bool EI { get; set; } = false;
        public DateTime? LastEIDate { get; set; }
        public bool JSA { get; set; } = false;
        public DateTime? LastJSADate { get; set; }
        public bool LO { get; set; } = false;
        public DateTime? LastLODate { get; set; }
        public bool CM { get; set; } = false;
        public DateTime? LastCMDate { get; set; }
        public bool PTW { get; set; } = false;
        public DateTime? LastPTWDate { get; set; }
        public bool PS { get; set; } = false;
        public DateTime? LastPSDate { get; set; }
        public bool SWA { get; set; } = false;
        public DateTime? LastSWADate { get; set; }
        public bool WH { get; set; } = false;
        public DateTime? LastWHDate { get; set; }        
    }
}
