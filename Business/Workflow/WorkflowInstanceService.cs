using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.DurableInstancing;
using System.Threading;
using System.Xml.Linq; 
using Ensco.Irma.Models.Domain.Workflow;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Interfaces.Services.Workflow;
using Ensco.Irma.Framework.Configuration;
using System.Diagnostics;

namespace Ensco.Irma.Business.Workflow
{
    /// <summary>
    /// Class that manages executing a Workflow
    /// </summary>
    public class WorkflowInstanceService : IWorkflowInstanceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowInstanceService"/> class.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <param name="version">The activity version.</param>
        /// <param name="extensions">The extensions.</param>
        public WorkflowInstanceService(Activity activity, Version version, ILog log, params object[] extensions)
        {
            Activity = activity;
            WorkflowVersion = version;
            Extensions = extensions;
            Unloaded = new AutoResetEvent(false);
            SynchronizationContext = new WorkflowSynchronizationContext();
            Name = activity.DisplayName;
            Log = log;
        }

        // A well known property that is needed by WorkflowApplication and the InstanceStore
        private static readonly XName WorkflowHostTypePropertyName = XNamespace.Get("urn:schemas-microsoft-com:System.Activities/4.0/properties").GetName("WorkflowHostType");

        /// <summary>
        /// Gets the activity.
        /// </summary>
        public Activity Activity { get; private set; }

        public Version  WorkflowVersion { get; private set; }

        private static string Name { get; set; }

        private static XName HostTypeName { get; set; }
        /// <summary>
        /// Gets the instance id.
        /// </summary>
        public Guid InstanceId { get; private set; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        public WorkflowResult Result { get; private set; }

        private object[] Extensions { get; set; }
        private WorkflowApplication Application { get; set; }
        private AutoResetEvent Unloaded { get; set; }
        private WorkflowSynchronizationContext SynchronizationContext { get; set; }

        /// <summary>
        /// Starts the specified workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        public void Start(Models.Domain.Workflow.WorkflowInstance workflow)
        {
            Log.Debug($"Start({workflow})");
            //TODO: Block concurrent calls to Start/Process?
            Unloaded.Reset();
            Result = new WorkflowResult();
            Application = CreateWorkflowApplication(workflow);
            Application.Run();
        }

        /// <summary>
        /// Processes the specified workflow, executing the specified <paramref name="transition"/> with the given <paramref name="request"/>
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="transition">The transition.</param>
        /// <param name="request">The request.</param>
        public void Process(WorkflowInstance workflow, WorkflowTransition transition, WorkflowRequest request)
        {
            Log.Debug($"Process({workflow}, {transition}, {request})");
            //TODO: Block concurrent calls to Start/Process?
            Unloaded.Reset();
            Result = new WorkflowResult();
            Application = CreateWorkflowApplication(workflow, false);
            //UnloadApplication(Application);
            if (!CheckForRunnableInstance())
                Application.Load(workflow.InstanceId);
            else
                Application.LoadRunnableInstance();

            Application.ResumeBookmark(transition.Name, request);
        }

        private void UnloadApplication(WorkflowApplication application)
        {
            try
            {
                // attempt to unload will fail if the workflow is idle within a NoPersistZone  
                application.Unload(TimeSpan.FromSeconds(5));
            }
            catch (TimeoutException e)
            {
                Debug.Write(e.Message);
            }
        }

        /// <summary>
        /// Waits for the workflow to reach the unloaded state.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        public bool WaitOne(TimeSpan timeout)
        {
            SynchronizationContext.ExecuteQueue(timeout);
            var ret = Unloaded.WaitOne(0);
            lock (Result)
            {
                if (Result != null && Result.Error != null)
                    throw Result.Error;
            }
            return ret;
        }

        private WorkflowApplication CreateWorkflowApplication(WorkflowInstance workflow, bool start = true)
        {
            WorkflowApplication ret = null;

            if (start)
            {
                var widentity = new WorkflowIdentity() { Name = workflow.Workflow.Name, Version = new Version(workflow.Workflow.Major, workflow.Workflow.Minor) };
                ret = new WorkflowApplication(Activity, workflow.Inputs, widentity)
                          {
                              InstanceStore = InstanceStore.Value,
                              PersistableIdle = (e) => PersistableIdleAction.Unload,
                              SynchronizationContext = SynchronizationContext,
                              Unloaded = OnUnload,
                              Idle = OnIdle,
                              Aborted = OnAbort,
                              Completed = OnComplete,
                              OnUnhandledException = OnException,
                          };
            }
            else
            {
                //, new WorkflowIdentity() { Name = Name, Version = WorkflowVersion }
                var widentity = new WorkflowIdentity() { Name = workflow.Workflow.Name, Version = new Version(workflow.Workflow.Major, workflow.Workflow.Minor) };

                ret = new WorkflowApplication(Activity, widentity)
                {
                    InstanceStore = InstanceStore.Value,
                    PersistableIdle = (e) => PersistableIdleAction.Unload,
                    SynchronizationContext = SynchronizationContext,
                    Unloaded = OnUnload,
                    Idle = OnIdle,
                    Aborted = OnAbort,
                    Completed = OnComplete,
                    OnUnhandledException = OnException,
                };
            }

            // Add the WorkflowHostType value to workflow application so that it stores this data in the instance store when persisted
            ret.AddInitialInstanceValues(new Dictionary<XName, object>
            {
                 { WorkflowHostTypePropertyName, HostTypeName }
            });

            var workflowInstanceTracker = new WorkflowInstanceStateTracker();
            workflowInstanceTracker.OnWorkflowInstanceStateChange += stateRecord =>
            {
                lock (Result)
                {
                    Result.NewState = new WorkflowState(stateRecord.StateName)
                    {
                        Context = Result.Context
                    };
                    Result.Context = null;
                }
            };

            //Track workflow in Events module
            //logging the workflow events to Event Viewer.
            /*
        
           EtwTrackingParticipant trackingParticipant =
                new EtwTrackingParticipant
                {

                    TrackingProfile = new TrackingProfile
                    {
                        Name = "SampleTrackingProfile",
                        ActivityDefinitionId = "ProcessOrder"
                    }
                };

            trackingParticipant.TrackingProfile.Queries.Add(new WorkflowInstanceQuery
            {
                States = { "*" }
            });
            
            ret.Extensions.Add(trackingParticipant);
            */

            ret.Extensions.Add(workflowInstanceTracker);
            ret.Extensions.Add(Result);
            foreach (var extension in Extensions)
            {
                ret.Extensions.Add(extension);
            }
            return ret;
        }

        private void OnComplete(WorkflowApplicationCompletedEventArgs arg)
        {
            Log.Debug("OnComplete({arg.InstanceId}, {arg.CompletionState})");
        }

        private UnhandledExceptionAction OnException(WorkflowApplicationUnhandledExceptionEventArgs arg)
        {
            Log.Warn("Error: {arg.ExceptionSource} - {arg.UnhandledException}");
            lock (Result)
            {
                Result.Error = arg.UnhandledException;
            }
            Unloaded.Set();
            return UnhandledExceptionAction.Abort;
        }

        private void OnAbort(WorkflowApplicationAbortedEventArgs arg)
        {
            Log.Warn("OnAbort({arg.Reason})");
            lock (Result)
            {
                Result.Error = arg.Reason;
            }

        }

        private void OnIdle(WorkflowApplicationIdleEventArgs arg)
        {
            Log.Debug("OnIdle({arg.Bookmarks.ToString(bm => bm.BookmarkName)})");
        }

        private void OnUnload(WorkflowApplicationEventArgs arg)
        {
            Log.Debug("OnUnload()");
            InstanceId = arg.InstanceId;
            Unloaded.Set();
            SynchronizationContext.CompleteWork();
        }

        static WorkflowInstanceService()
        {
            InstanceStore = new Lazy<InstanceStore>(CreateInstanceStore);
        }

        private ILog Log { get; set; }

        private static InstanceHandle Handle { get; set; }

        private static InstanceStore CreateInstanceStore()
        {
            var store = new SqlWorkflowInstanceStore(FrameworkEnvironment.Instance.Configuration.GetConnectionString())
            {
                InstanceEncodingOption = InstanceEncodingOption.GZip,
                RunnableInstancesDetectionPeriod = TimeSpan.FromSeconds(10),
                HostLockRenewalPeriod = TimeSpan.FromSeconds(10),
                InstanceCompletionAction = InstanceCompletionAction.DeleteNothing,
                InstanceLockedExceptionAction = InstanceLockedExceptionAction.AggressiveRetry
            };

            HostTypeName = XName.Get(Name, typeof(WorkflowInstanceService).FullName ?? string.Empty);

            Handle = CreateOwnerHandle(store);

            //store.Execute(Handle, new DeleteWorkflowOwnerCommand(), TimeSpan.FromSeconds(10));
            Handle.Free(); 
            return store; 
        }


        private static InstanceHandle CreateOwnerHandle(InstanceStore store)
        { 
            var ownerHandle = store.CreateInstanceHandle();

            var instanceView = store.Execute(ownerHandle,
                new CreateWorkflowOwnerCommand()
                {
                    InstanceOwnerMetadata =
                    {
                {WorkflowHostTypePropertyName, new InstanceValue(HostTypeName) }
                    }
                }
                , TimeSpan.FromSeconds(5)
                );

            store.DefaultInstanceOwner = instanceView.InstanceOwner;

            return ownerHandle;
        }

        private class WorkflowSynchronizationContext : SynchronizationContext
        {
            public bool ExecuteQueue(TimeSpan timeout)
            {
                DateTime maxEndTime = DateTime.Now + timeout;
                do
                {
                    Action action;
                    timeout = maxEndTime - DateTime.Now;
                    if (timeout.TotalMilliseconds < 0)
                        return false;
                    if (WorkQueue.TryTake(out action, timeout))
                        action();
                } while (!WorkQueue.IsAddingCompleted && DateTime.Now < maxEndTime);
                return WorkQueue.IsCompleted;
            }

            public void CompleteWork()
            {
                WorkQueue.CompleteAdding();
            }

            private BlockingCollection<Action> WorkQueue = new BlockingCollection<Action>();

            public override void Post(SendOrPostCallback d, object state)
            {
                WorkQueue.Add(() => d(state));
            }

            public override void Send(SendOrPostCallback d, object state)
            {
                var finished = new ManualResetEvent(false);
                WorkQueue.Add(() =>
                                  {
                                      try
                                      {
                                          d(state);
                                      }
                                      finally
                                      {
                                          finished.Set();
                                      }
                                  });
                finished.WaitOne();
            }

            private static readonly ILog Log = Logging.Log.GetLogger(typeof(WorkflowSynchronizationContext));
        }

        private static bool CheckForRunnableInstance()
        {
            var events = new List<InstancePersistenceEvent>();

            try
            {
                if (InstanceStore.IsValueCreated && !Handle.IsValid)
                {
                    var ownerHandle = (!Handle.IsValid) ? CreateOwnerHandle(InstanceStore.Value) : Handle;
                    events = InstanceStore.Value.WaitForEvents(ownerHandle, TimeSpan.FromSeconds(1));
                    ownerHandle.Free();
                }
            }
            catch (Exception e)
            {
                //Time out exception
                ;
            }

            return events.Any(pe => pe.Equals(HasRunnableWorkflowEvent.Value));
        }

        private static Lazy<InstanceStore> InstanceStore { get; set; }
    }
}
