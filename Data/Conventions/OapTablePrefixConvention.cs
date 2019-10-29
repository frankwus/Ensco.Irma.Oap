using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using Ensco.Irma.Models.Domain.Attributes;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Pluralization;

namespace Ensco.Irma.Data.Conventions
{
    public class OapTablePrefixConvention: Convention
    {
        public OapTablePrefixConvention()
        {
            string prefix = "Oap_";
            var myList = new List<string>();
            try
            {
                var plural =  new EnglishPluralizationService();
                
                //TODO: Modify this to use a custom attribute to not apply this default convention.
                Types().Where(t => !t.CustomAttributes.Any(ca => ca.AttributeType == (typeof(NonOapEntity)))).Configure(c =>
                {
                    var tableName = plural.Pluralize($"{prefix}{c.ClrType.Name}s");
                    c.ToTable(tableName);
                    myList.Add(tableName);
                });
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }
    }
}
