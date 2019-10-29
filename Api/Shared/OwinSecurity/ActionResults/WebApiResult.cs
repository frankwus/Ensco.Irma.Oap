using System;
using System.Collections.Generic;
using System.Linq;

namespace Ensco.Irma.Oap.Api.Common.ActionResults
{
    public class WebApiResult<T>
    {
        public T Data { get; set; }

        public IList<string> Errors { get; set; } = new List<string>();

        public WebApiResult()
        {

        }
        public WebApiResult(T data, IEnumerable<string> errors):this(data)
        { 
            Errors = errors.ToList();
        }
        public WebApiResult(T data)
        {
            T Data = data; 
        }

        public void SetError(string err, Exception ex = null)
        {

            if (err != null)
            {
               Errors.Add(err);
            }

            if (ex != null)
            {
                var stack = ex.StackTrace;

                while (ex != null)
                {
                    Errors.Add(ex.Message);
                    ex = ex.InnerException;
                }

            }

        }
    }
}