using Ensco.Irma.Models.Domain.Workflow;
using System;
using System.Activities; 

namespace Ensco.Irma.Business.Workflow.Activities
{
    [DefaultRequestVerb("Assign")]
    public class ReceiveAssignment : ReceiveRequest<AssignmentRequest>
    {
        public InArgument<bool> PromptForPeople { get; set; }

        public InArgument<string> PromptFilter { get; set; }

        protected override WorkflowTransition CreateWorkflowTransition(NativeActivityContext context, string bookmarkName, string requiredPermission)
        {
            return new AssignmentTransition(bookmarkName, requiredPermission)
            {
                PromptForPeople = PromptForPeople.Get(context),
                PromptFilter = PromptFilter.Get(context)
            };
        }
    }
}
