using System;
using System.Activities;
using Business;
using Intellitide.Domain.Workflow;

namespace Intellitide.Business.Workflow
{
    /// <summary>
    /// Manager class that handles execution of Workflows
    /// </summary>
    public class WorkflowManager : IWorkflowManager
    {
        /// <summary>
        /// Starts the specified activity.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <param name="workflow">The workflow.</param>
        /// <param name="timeout">The timeout.</param>
        public void Start(Activity activity, IWorkflow workflow, TimeSpan timeout)
        {
            //Guard.AgainstNull(() => activity);
            //Guard.AgainstNull(() => workflow);

            var instance = new IntellitideWorkflowInstance(activity, FrameworkEnvironment.Instance);
            using (new TransactionScope())
            {
                instance.Start(workflow);
                if (!instance.WaitOne(timeout))
                    throw new TimeoutException("Timeout waiting for unload from workflow engine");
            }
            workflow.WorkflowInstanceId = instance.InstanceId;
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
        public void Process(Activity activity, IWorkflow workflow, WorkflowTransition transition, WorkflowRequest request, TimeSpan timeout)
        {
            //Guard.AgainstNull(() => activity);
            //Guard.AgainstNull(() => workflow);
            //Guard.AgainstNull(() => transition);
            //Guard.AgainstNull(() => request);

            var instance = new IntellitideWorkflowInstance(activity, FrameworkEnvironment.Instance.Container);
            using (new TransactionScope(TransactionScopeOption.Suppress))
            {
                instance.Process(workflow, transition, request);
                if (!instance.WaitOne(timeout))
                    throw new TimeoutException("Timeout waiting for unload from workflow engine");
            }
            UpdateWorkflowState(workflow, instance.Result, transition);
        }

        private void UpdateWorkflowState(IWorkflow workflow, WorkflowResult result, WorkflowTransition transition)
        {
            if (result.NewState.Name != null && (workflow.CurrentState == null || result.NewState.Name != workflow.CurrentState.Name))
            {
                workflow.CurrentState = result.NewState;
                if (transition != null)
                    workflow.CurrentState.Entry = transition;
            }
        }

        private static readonly ILog Log = LogManager.GetLogger(typeof(WorkflowManager));
    }
     
}
