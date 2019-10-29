using System;
using System.Collections.Generic;

namespace Ensco.Irma.Models.Domain.Workflow
{
    [Serializable]
    public class ApprovalRequest : WorkflowRequest
    {
        public IDictionary<string, object> Inputs { get; set; } = new Dictionary<string, object>();

        public ApprovalRequest():base()
        {

        }

        public ApprovalRequest(IDictionary<string, object> inputs) : this()
        {
            Inputs = inputs;
        }


         
    }
}
