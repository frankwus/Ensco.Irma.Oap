using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Models.Domain.Attributes
{
    public class SqlDefaultValueAttribute : Attribute
    {

        public SqlDefaultValueAttribute(string value)
        {
            Value = value;
        }
        public virtual string Value { get; }
    }
}
