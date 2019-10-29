using System;
using System.Activities;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Workflow;

namespace Ensco.Irma.Interfaces.Services.Workflow
{
    public interface IWorkflowEngineService
    {
        void Start(Activity activity,Version version, WorkflowInstance state, int timeoutInSeconds = 60);

        void Process(Activity activity,Version version, WorkflowInstance state, WorkflowTransition transition, WorkflowRequest request, int timeoutInSeconds = 60);
    }
}
