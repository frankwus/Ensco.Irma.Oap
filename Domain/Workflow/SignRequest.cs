using System;
using System.Collections.Generic;

namespace Ensco.Irma.Models.Domain.Workflow
{
    [Serializable]
    public class SignRequest : WorkflowRequest
    {
        public IDictionary<string, object> Inputs { get; set; } = new Dictionary<string, object>();

        public SignRequest():base()
        {

        }

        public SignRequest(IDictionary<string, object> inputs) : this()
        {
            Inputs = inputs;
        }


         
    }
}
