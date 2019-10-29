using AutoMapper;
using Ensco.Irma.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Mapper
{
    public static class AutoMapperExtension
    {
        public static void AddOrUpdate<T1, Id1>(this IMapper mapper, ICollection<T1> source, ICollection<T1> dest, Func<ICollection<T1>, T1, T1> matchCondition)
        where T1 : class, IEntityId<Id1>
        where Id1 : struct
        { 
            //delete scenario
            foreach (var q in dest)
            {
                var value = (source != null) ? matchCondition.Invoke(source, q) : null;
                if (value == null)
                {
                    dest.Remove(q);
                }
            }

            //Add or Update
            if (source != null)
            {
                foreach (var q in source)
                {
                    if (matchCondition.Invoke(dest, q) == null)
                    {
                        dest.Add(q);
                    }
                    else
                    {
                        var value = matchCondition.Invoke(dest, q);
                        if (value != null)
                        {
                            mapper.Map<T1, T1>(q, value);
                        }
                    }
                }
            }

            
        }
    }
}
