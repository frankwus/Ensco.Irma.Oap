using System;
using Ensco.Irma.Models.Domain.Security;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ensco.Irma.Models.Domain.Workflow
{
    [Serializable]
    public class AssignmentRequest : WorkflowRequest
    {
        public AssignmentRequest()
        {
            Users = new Collection<AssignedUser>();
        }

        [Column(Order = 3)] 
        [Required]
        public virtual ICollection<AssignedUser> Users { get; set; }
    }
}
