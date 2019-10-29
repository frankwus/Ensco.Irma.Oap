using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Models.Domain.Oap
{
    public class RigChecklistValidationResult
    {
        public RigChecklistValidationResult()
        {
            Errors = new List<string>();
        }        
        public bool Success => Errors.Count == 0;
        public IList<string> Errors { get; set; }

        public void AddError(string message)
        {
            Errors.Add(message);
        }
    }
}
