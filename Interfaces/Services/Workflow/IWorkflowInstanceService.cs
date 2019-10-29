using Ensco.Irma.Models.Domain.Workflow;
using System;
using System.Activities;

namespace Ensco.Irma.Interfaces.Services.Workflow
{
    public interface IWorkflowInstanceService
    {
        void Process(WorkflowInstance workflow, WorkflowTransition transition, WorkflowRequest request);

        void Start(WorkflowInstance workflow);

        bool WaitOne(TimeSpan timeout);

         Activity Activity { get; }

         Version WorkflowVersion { get; }
         
        /// <summary>
        /// Gets the instance id.
        /// </summary>
         Guid InstanceId { get; }

    }
}