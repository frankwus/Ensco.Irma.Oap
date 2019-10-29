using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.DurableInstancing;
using System.Threading;
using System.Xml.Linq;
using log4net;
using Intellitide.Domain.Workflow;
using Business;

namespace Intellitide.Business.Workflow
{
    /// <summary>
    /// Class that manages executing a Workflow
    /// </summary>
    public class IntellitideWorkflowInstance
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntellitideWorkflowInstance"/> class.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <param name="extensions">The extensions.</param>
        public IntellitideWorkflowInstance(Activity activity, params object[] extensions)
        {
            Activity = activity;
            Extensions = extensions;
            Unloaded = new AutoResetEvent(false);
            SynchronizationContext = new WorkflowSynchronizationContext();
            Name = activity.DisplayName;
        }

        // A well known property that is needed by WorkflowApplication and the InstanceStore
        private static readonly XName WorkflowHostTypePropertyName = XNamespace.Get("urn:schemas-microsoft-com:System.Activities/4.0/properties").GetName("WorkflowHostType");

        /// <summary>
        /// Gets the activity.
        /// </summary>
        public Activity Activity { get; private set; }

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
        public void Start(IWorkflow workflow)
        {
            Log.DebugFormat("Start({0})", workflow);
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
        public void Process(IWorkflow workflow, WorkflowTransition transition, WorkflowRequest request)
        {
            Log.DebugFormat("Process({0}, {1}, {2})", workflow, transition, request);
            //TODO: Block concurrent calls to Start/Process?
            Unloaded.Reset();
            Result = new WorkflowResult();
            Application = CreateWorkflowApplication(null);
            if (!CheckForRunnableInstance())
                Application.Load(workflow.WorkflowInstanceId);
            else
                Application.LoadRunnableInstance();

            Application.ResumeBookmark(transition.Name, request);
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

        private WorkflowApplication CreateWorkflowApplication(IWorkflow workflow)
        {
            WorkflowApplication ret = null;

            if (workflow != null)
            {
                ret = new WorkflowApplication(Activity, workflow.GetInputs())
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
                ret = new WorkflowApplication(Activity)
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
            ret.Extensions.Add(new WorkflowStateTracker(stateRecord =>
                                                            {
                                                                lock (Result)
                                                                {
                                                                    Result.NewState = new WorkflowState(stateRecord.StateName)
                                                                                          {
                                                                                              Context = Result.Context
                                                                                          };
                                                                    Result.Context = null;
                                                                }
                                                            }));
            ret.Extensions.Add(Result);
            foreach (var extension in Extensions)
            {
                ret.Extensions.Add(extension);
            }
            return ret;
        }

        private void OnComplete(WorkflowApplicationCompletedEventArgs arg)
        {
            Log.DebugFormat("OnComplete({0}, {1})", arg.InstanceId, arg.CompletionState);
        }

        private UnhandledExceptionAction OnException(WorkflowApplicationUnhandledExceptionEventArgs arg)
        {
            Log.WarnFormat("Error: {0} - {1}", arg.ExceptionSource, arg.UnhandledException);
            lock (Result)
            {
                Result.Error = arg.UnhandledException;
            }
            Unloaded.Set();
            return UnhandledExceptionAction.Abort;
        }

        private void OnAbort(WorkflowApplicationAbortedEventArgs arg)
        {
            Log.WarnFormat("OnAbort({0})", arg.Reason);
            lock (Result)
            {
                Result.Error = arg.Reason;
            }

        }

        private void OnIdle(WorkflowApplicationIdleEventArgs arg)
        {
            Log.DebugFormat("OnIdle({0})", arg.Bookmarks.ToString(bm => bm.BookmarkName));
        }

        private void OnUnload(WorkflowApplicationEventArgs arg)
        {
            Log.DebugFormat("OnUnload()");
            InstanceId = arg.InstanceId;
            Unloaded.Set();
            SynchronizationContext.CompleteWork();
        }

        static IntellitideWorkflowInstance()
        {
            InstanceStore = new Lazy<InstanceStore>(CreateInstanceStore);
        }

        private static readonly Interfaces.ILog Log = Logging.Log.GetLogger(typeof(IntellitideWorkflowInstance));

        private static InstanceStore CreateInstanceStore()
        {
            var store = new SqlWorkflowInstanceStore(FrameworkEnvironment.Instance.Configuration.GetConnectionString())
            {
                InstanceEncodingOption = InstanceEncodingOption.GZip,
                RunnableInstancesDetectionPeriod = TimeSpan.FromSeconds(5),
                HostLockRenewalPeriod = TimeSpan.FromSeconds(5),
                InstanceCompletionAction = InstanceCompletionAction.DeleteAll,
                InstanceLockedExceptionAction = InstanceLockedExceptionAction.AggressiveRetry
            };

            HostTypeName = XName.Get(Name, typeof(IntellitideWorkflowInstance).FullName ?? string.Empty);

            CreateOwnerHandle(store).Free();

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

            private static readonly ILog Log = LogManager.GetLogger(typeof(WorkflowSynchronizationContext));
        }

        private static bool CheckForRunnableInstance()
        {
            var events = new List<InstancePersistenceEvent>();

            try
            {
                if (InstanceStore.IsValueCreated)
                {
                    var ownerHandle = CreateOwnerHandle(InstanceStore.Value);
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
