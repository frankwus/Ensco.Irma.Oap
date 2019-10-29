using System;
using System.ComponentModel;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public enum OapChecklistType
    {
        [Description("Barrier Authority Checklist")]
        BarrierAuthority = 1,
        [Description("Generic Checklist")]
        CriticalAreaVerification = 2,
        [Description("Oversight")]
        Oversight = 3,
        [Description("Operational Assurance Protocol")]
        OperationalAssuranceProtocol = 4
    }

    public static class EnumExtentions
    {
        public static string ToDecription(this OapChecklistType input)
        {
            var fi = input.GetType().GetField(input.ToString());
            var attrs = (DescriptionAttribute[]) fi.GetCustomAttributes(typeof(DescriptionAttribute), false);


            return (attrs != null) && attrs.Length > 0 ? attrs[0].Description : input.ToString();
        }
        
       
    }
}
