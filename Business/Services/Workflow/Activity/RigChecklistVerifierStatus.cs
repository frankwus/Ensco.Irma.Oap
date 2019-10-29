using Ensco.Irma.Framework.Configuration;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Workflow;
using System;
using System.Activities;
using System.Linq;

namespace Ensco.Irma.Services.Workflow.Activity
{
    public class RigChecklistVerifierStatus : RigChecklistBaseActivity
    {
        protected override void Execute(NativeActivityContext context)
        {
            base.Execute(context);
              
            RigChecklistService.Save(RigChecklist);
        }
    }

}
