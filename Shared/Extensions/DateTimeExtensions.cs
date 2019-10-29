using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsDefaultMin(this DateTime input)
        {
            return input == DateTime.MinValue;
        }

        public static bool IsDefaultMax(this DateTime input)
        {
            return input == DateTime.MaxValue;
        }
    }
}
