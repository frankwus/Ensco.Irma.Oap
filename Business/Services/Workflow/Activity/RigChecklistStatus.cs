using Ensco.Irma.Framework.Configuration;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Workflow;
using System;
using System.Activities;
using System.Linq;

namespace Ensco.Irma.Services.Workflow.Activity
{
    public class RigChecklistStatus : RigChecklistBaseActivity
    {

        [RequiredArgument]
        public InArgument<string> Status { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            base.Execute(context);

            var status = Status.Get(context);

            RigChecklist.Status = status;

            RigChecklistService.Save(RigChecklist);
        }
    }

}
