using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Workflow;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig.Workflow
{
    public class GetAllRigOapChecklistWorkflowHandler : IRequestHandler<GetAllRigOapChecklistWorkflowRequest, IEnumerable<RigOapChecklistWorkflow>>
    {
        private IRigOapChecklistWorkflowService RigOapChecklistWorkflowService { get; set; }

        public GetAllRigOapChecklistWorkflowHandler(IRigOapChecklistWorkflowService rigOapChecklistWorkflowService)
        {
            RigOapChecklistWorkflowService = rigOapChecklistWorkflowService;
        }

        Task<IEnumerable<RigOapChecklistWorkflow>> IRequestHandler<GetAllRigOapChecklistWorkflowRequest, IEnumerable<RigOapChecklistWorkflow>>.Handle(GetAllRigOapChecklistWorkflowRequest request, CancellationToken cancellationToken)
        {
            var cl = RigOapChecklistWorkflowService.GetAll();
            return Task.FromResult(cl);
        }
    }
}