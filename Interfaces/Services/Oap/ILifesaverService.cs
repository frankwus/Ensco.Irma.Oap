using Ensco.Irma.Models.Domain.Oap.Checklist.Lifesaver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Interfaces.Services.Oap
{
    public interface ILifesaverService
    {
        LifesaverCompliance GetComplianceStatus();
    }
}
