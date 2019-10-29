using System;
using System.Activities;
using System.Transactions; 
using Ensco.Irma.Models.Domain.Workflow; 
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Interfaces.Services.Workflow;

namespace Ensco.Irma.Business.Workflow
{
    /// <summary>
    /// Manager class that handles execution of Workflows
    /// </summary>
    public class WorkflowEngineService : IWorkflowEngineService
    {
        public WorkflowEngineService(ILog log)
        {
            Log = log;
        }
        /// <summary>
        /// Starts the specified activity.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <param name="Version">The workflow version.</param>
        /// <param name="workflow">The workflow.</param>
        /// <param name="timeout">The timeout.</param>
        public void Start(Activity activity, Version version, WorkflowInstance workflow, int timeoutInSeconds = 60)
        {
            //Guard.AgainstNull(() => activity);
            //Guard.AgainstNull(() => workflow);

            var timeout = new TimeSpan(0, 0, timeoutInSeconds);
            var instance = new WorkflowInstanceService(activity, version, Log);
            /*
             * Cannot use transaction scope as this causes locks not be created
             * with Windows workflow store procedures
             * 
                using (new TransactionScope())
                {
                    instance.Start(workflow);
                    if (!instance.WaitOne(timeout))
                        throw new TimeoutException("Timeout waiting for unload from workflow engine");
                }
            */

            instance.Start(workflow);

            if (!instance.WaitOne(timeout))
                throw new TimeoutException("Timeout waiting for unload from workflow engine");

            workflow.InstanceId = instance.InstanceId;

            UpdateWorkflowState(workflow, instance.Result, null);
        }

        /// <summary>
        /// Processes the specified activity.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <param name="workflow">The workflow.</param>
        /// <param name="transition">The transition.</param>
        /// <param name="request">The request.</param>
        /// <param name="timeout">The timeout.</param>
        public void Process(Activity activity, Version version, WorkflowInstance workflow, WorkflowTransition transition, WorkflowRequest request, int timeoutInSeconds = 60)
        {
            //Guard.AgainstNull(() => activity);
            //Guard.AgainstNull(() => workflow);
            //Guard.AgainstNull(() => transition);
            //Guard.AgainstNull(() => request);
            var timeout = new TimeSpan(0, 0, timeoutInSeconds);
            var instance = new WorkflowInstanceService(activity, version, Log);

            /*
             * Cannot use transaction scope as this causes locks not be created
             * with Windows workflow store procedures
             * 
            using (new TransactionScope(TransactionScopeOption.Suppress))
            {
                instance.Process(workflow, transition, request);
                if (!instance.WaitOne(timeout))
                    throw new TimeoutException("Timeout waiting for unload from workflow engine");
            }

            */

            instance.Process(workflow, transition, request);

            if (!instance.WaitOne(timeout))
                throw new TimeoutException("Timeout waiting for unload from workflow engine");

            UpdateWorkflowState(workflow, instance.Result, transition);
        }

        private void UpdateWorkflowState(WorkflowInstance workflow, WorkflowResult result, WorkflowTransition transition)
        {
            if (result.NewState?.Name != null && (workflow.WorkflowState?.Name == null || result.NewState?.Name != workflow.WorkflowState?.Name))
            {
                workflow.WorkflowState = result.NewState;

                if (transition != null)
                    workflow.Transition = transition;
            }
        }

        private ILog Log { get; set; }
    }
     
}
