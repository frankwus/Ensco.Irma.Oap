using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Workflow;
using System;
using System.Activities;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;

namespace Ensco.Irma.Business.Workflow.Activities
{
    public abstract class ReceiveRequest<TRequest> : NativeActivity<TRequest>
        where TRequest : WorkflowRequest
    {
        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        [Description("A Custom Request Verb")]
        public InArgument<string> RequestVerb { get; set; }

        [Description("The Permission required to perform this transition")]
        public InArgument<string> RequiredPermission { get; set; }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            metadata.RequireExtension<WorkflowResult>();
            base.CacheMetadata(metadata);
        }
        protected override void Execute(NativeActivityContext context)
        {
            var bookmarkName = GetBookmarkName(context);

            Log.Debug("Execute({context.WorkflowInstanceId}, {bookmarkName})");

            var requiredPermission = RequiredPermission.Get(context);

            var workflowResult = context.GetExtension<WorkflowResult>();

            //Only create Bookmark the first time the activity is executed.
            if (!workflowResult.NewState.Transitions.Any(t => t.Name == bookmarkName && t.RequiredPermission == requiredPermission))
            {
                workflowResult.NewState.Transitions.Add(CreateWorkflowTransition(context, bookmarkName, requiredPermission));
            }

            context.CreateBookmark(bookmarkName, OnResumeBookmark);
        }

        protected abstract WorkflowTransition CreateWorkflowTransition(NativeActivityContext context, string bookmarkName, string requiredPermission);

        private string GetBookmarkName(NativeActivityContext context)
        {
            var name = RequestVerb.Get(context);

            if (!String.IsNullOrEmpty(name))
                return name;

            var attribute = (DefaultRequestVerbAttribute)GetType().GetCustomAttributes(typeof(DefaultRequestVerbAttribute), false).FirstOrDefault(); //GetAttribute<DefaultRequestVerbAttribute>();

            if (attribute == null)
            {
                throw new InvalidOperationException("Request verb not specified in workflow and no DefaultRequestVerbAttribute provided for " + GetType().Name);
            }

            return attribute.Verb;
        }

        private void OnResumeBookmark(NativeActivityContext context, Bookmark bookmark, Object value)
        {
            Log.Debug("OnResumeBookmark({bookmark.Name}, {value})");

            var requiredPermission = RequiredPermission.Get(context);

            if (!String.IsNullOrEmpty(requiredPermission))
            {
                //Log.DebugFormat("Ensuring {0} has {1} permission", ((Account)Thread.CurrentPrincipal).Person, requiredPermission);
                var perm = new PrincipalPermission(null, requiredPermission);
                perm.Demand();
            }

            if (!(value is TRequest request))
            {
                throw new ArgumentOutOfRangeException(String.Format("Expected {0} but received {1}", typeof(TRequest).Name, value));
            }

            OnRequest(context, request);
        }

        protected virtual void OnRequest(NativeActivityContext context, TRequest request)
        {
            context.SetValue(Result, request);
        }

        private static readonly ILog Log = Logging.Log.GetLogger(typeof(ReceiveRequest<TRequest>));
    }
}
