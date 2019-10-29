using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ensco.Irma.Models.Domain.Workflow
{
    [Serializable]
    public class RejectionRequest : WorkflowRequest
    {

        public RejectionRequest(string reason, string details, IDictionary<string, object> inputs)
        {
            Reason = reason;
            Details = details;
            Inputs = inputs;
        }

        public RejectionRequest()
        {
        }

        [Required]
        [StringLength(1024)]
        public string Reason { get; set; }

        public string Details { get; set; }

        public IDictionary<string, object> Inputs { get; set; } = new Dictionary<string, object>();
 

    }
}
