using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Workflow;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig.Workflow
{
    public class GetRigOapChecklistWorkflowHandler : IRequestHandler<GetRigOapChecklistWorkflowRequest, RigOapChecklistWorkflow>
    {
        private Interfaces.Services.Oap.IRigOapChecklistWorkflowService RigOapChecklistWorkflowService { get; set; }

        public GetRigOapChecklistWorkflowHandler(IRigOapChecklistWorkflowService rigOapChecklistWorkflowService)
        {
            RigOapChecklistWorkflowService = rigOapChecklistWorkflowService;
        }

        Task<RigOapChecklistWorkflow> IRequestHandler<GetRigOapChecklistWorkflowRequest, RigOapChecklistWorkflow>.Handle(GetRigOapChecklistWorkflowRequest request, CancellationToken cancellationToken)
        {
            var cl = RigOapChecklistWorkflowService.GetWorkflowByChecklist(request.RigOapChecklistId);
            return Task.FromResult(cl);
        }
    }
}