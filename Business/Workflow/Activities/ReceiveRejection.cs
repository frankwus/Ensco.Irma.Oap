using System.Activities;
using Ensco.Irma.Models.Domain.Workflow;
using Ensco.Irma.Interfaces.Services.Logging; 

namespace Ensco.Irma.Business.Workflow.Activities
{
    [DefaultRequestVerb("Reject")]
    public class ReceiveRejection : ReceiveRequest<RejectionRequest>
    {
        protected override WorkflowTransition CreateWorkflowTransition(NativeActivityContext context, string bookmarkName, string requiredPermission)
        {
            return new RejectionTransition(bookmarkName, requiredPermission);
        }

        protected override void OnRequest(NativeActivityContext context, RejectionRequest request)
        {
            var result = context.GetExtension<WorkflowResult>();
            result.Context = request.Reason;
            Log.Info($"Rejection Reason {request.Details}");
            base.OnRequest(context, request);
        }

        private static readonly ILog Log = Logging.Log.GetLogger(typeof(ReceiveRejection));
    }
}
