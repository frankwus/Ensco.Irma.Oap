using Ensco.Irma.Framework.Configuration;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Workflow;
using System;
using System.Activities;
using System.Linq;

namespace Ensco.Irma.Services.Workflow.Activity
{
    public class RigChecklistAssignment : RigChecklistBaseActivity
    {
        
        [RequiredArgument]
        public InArgument<AssignmentRequest> Owner { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            base.Execute(context);

            var ownerAssignmentRequest = Owner.Get(context);

            if (!ownerAssignmentRequest.Users.Any())
            {
                return;
            }

            RigChecklist.OwnerId = ownerAssignmentRequest.Users.First().Id;
            RigChecklistService.Save(RigChecklist);
        }
    }

}
