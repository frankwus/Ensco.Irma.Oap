using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig.Workflow
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Interfaces.Services.Oap;
    using Ensco.Irma.Interfaces.Services.Security;
    using Ensco.Irma.Interfaces.Services.Workflow;
    using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Workflow;
    using Ensco.Irma.Oap.Api.Rig.Extensions;

    public class StartRigOapChecklistWorkflowHandler : IRequestHandler<StartRigOapChecklistWorkflowRequest, bool>
    {
        public IRigOapChecklistService RigOapChecklistService { get; }

        private IRigOapChecklistWorkflowService RigOapChecklistWorkflowService { get; set; }

        public IWorkflowEngineService WorkflowEngineService { get; }

        public IPeopleService PeopleService { get; }
        public ILog Log { get; }
        private IWorkflowService WorkflowService { get; set; }

        public StartRigOapChecklistWorkflowHandler(IRigOapChecklistService rigOapChecklistService, IRigOapChecklistWorkflowService rigOapChecklistWorkflowService, IWorkflowService workflowService, IWorkflowEngineService workflowEngineService, IPeopleService peopleService, ILog log)
        {
            WorkflowService = workflowService;
            RigOapChecklistService = rigOapChecklistService;
            WorkflowEngineService = workflowEngineService;
            RigOapChecklistService = rigOapChecklistService;
            RigOapChecklistWorkflowService = rigOapChecklistWorkflowService;
            PeopleService = peopleService;
            Log = log;
        }

        Task<bool> IRequestHandler<StartRigOapChecklistWorkflowRequest, bool>.Handle(StartRigOapChecklistWorkflowRequest request, CancellationToken cancellationToken)
        {
            var existingRigChecklist = RigOapChecklistService.Get(request.RigChecklistId);
            if (existingRigChecklist == null)
            {
                return Task.FromResult(false);
            }

            //existingRigChecklist.StartWorkflow(RigOapChecklistWorkflowService, WorkflowEngineService, WorkflowService, PeopleService, Log, request.OwnerId);

            RigOapChecklistWorkflowService.StartChecklistWorkFlow(existingRigChecklist);

            return Task.FromResult(true);
        }
    }
}