using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Models.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NonOapEntity : Attribute
    {
    }
}
