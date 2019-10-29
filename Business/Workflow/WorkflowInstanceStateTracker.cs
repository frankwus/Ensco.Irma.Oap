using Ensco.Irma.Interfaces.Services.Logging;
using System;
using System.Activities.Statements.Tracking;
using System.Activities.Tracking;

namespace Ensco.Irma.Business.Workflow
{
    public class WorkflowInstanceStateTracker : TrackingParticipant
    {
        private readonly ILog Log = Logging.Log.GetLogger(typeof(WorkflowInstanceStateTracker));

        public WorkflowInstanceStateTracker()
        { 
        }

        public event Action<StateMachineStateRecord> OnWorkflowInstanceStateChange;

        public event Action<ActivityStateRecord> OnWorkflowInstanceActivityChange;

        public event Action<WorkflowInstanceRecord> OnWorkflowInstanceChange;

        protected override void Track(TrackingRecord record, TimeSpan timeout)
        {
            if (record is StateMachineStateRecord)
            {
                var stateMachineRecord = (StateMachineStateRecord)record;
                Log.Debug("State Change {stateMachineRecord.InstanceId}: {stateMachineRecord.StateName}");

                OnWorkflowInstanceStateChange?.Invoke(stateMachineRecord);
            }
            else if (record is ActivityStateRecord)
            {
                var activityStateRecord = (ActivityStateRecord)record;
                if (activityStateRecord.Activity.TypeName == "System.Activities.Statements.InternalState")
                    Log.Debug("Activity State: {stateRecord.InstanceId} - {stateRecord.Activity.Name} ({stateRecord.State})");
                OnWorkflowInstanceActivityChange?.Invoke(activityStateRecord);
            }
            else if (record is WorkflowInstanceRecord)
            {
                var instanceRecord = (WorkflowInstanceRecord)record; 
                    Log.Debug($"Instance State: {instanceRecord.InstanceId} - {instanceRecord.ActivityDefinitionId} ({instanceRecord.State})");
                OnWorkflowInstanceChange?.Invoke(instanceRecord);
            }
        }

        
         
    }
}
