using AutoMapper;
using Ensco.Irma.Interfaces.Services.Logging;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Interfaces.Services.Security;
using Ensco.Irma.Interfaces.Services.Workflow;
using Ensco.Irma.Models.Domain.Workflow;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.WorkFlow;
using Ensco.Irma.Models.Domain.Oap.Audit;
//using Ensco.Irma.Oap.Api.Rig.Extensions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.OapAudits
{
    public class ProcessOapAuditWorkFlowHandler : IRequestHandler<ProcessOapAuditWorkFlowRequest, bool>
    {

        public IRigOapChecklistService RigOapChecklistService { get; }

        private IRigOapChecklistWorkflowService RigOapChecklistWorkflowService { get; set; }

        public IWorkflowEngineService WorkflowEngineService { get; }

        public IPeopleService PeopleService { get; }

        public IOapAuditService OapAuditService { get; }

        public ILog Log { get; }

        private IWorkflowService WorkflowService { get; set; }

        public ProcessOapAuditWorkFlowHandler(IRigOapChecklistService rigOapChecklistService, IRigOapChecklistWorkflowService rigOapChecklistWorkflowService, IWorkflowService workflowService, IWorkflowEngineService workflowEngineService, IPeopleService peopleService, IOapAuditService auditService, ILog log)
        {
            WorkflowService = workflowService;
            RigOapChecklistService = rigOapChecklistService;
            WorkflowEngineService = workflowEngineService;
            //RigOapChecklistService = rigOapChecklistService;
            RigOapChecklistWorkflowService = rigOapChecklistWorkflowService;
            PeopleService = peopleService;
            OapAuditService = auditService;
            Log = log;
        }

        Task<bool> IRequestHandler<ProcessOapAuditWorkFlowRequest, bool>.Handle(ProcessOapAuditWorkFlowRequest request, CancellationToken cancellationToken)
        {
            var existingRigChecklist = RigOapChecklistService.Get(request.RigChecklistId);
            if (existingRigChecklist == null)
            {
                return Task.FromResult(false);
            }

            switch (request.Transition.ToLower())
            {
                case "sign":
                    RigOapChecklistWorkflowService.SignWorkFlow(existingRigChecklist, request.UserId, request.Order, request.Comment);
                    break;
                case "review":
                    RigOapChecklistWorkflowService.Review(existingRigChecklist, request.UserId, request.Order, request.Comment);
                    UpdateAuditStatus(request.Audit);
                    break;
                case "reject":
                    RigOapChecklistWorkflowService.RejectWorkFlow(existingRigChecklist, request.UserId, request.Order, request.Comment);
                    break;
                case "cancel":
                    RigOapChecklistWorkflowService.Cancel(existingRigChecklist, request.UserId, request.Order, request.Comment);
                    break;
                default:
                    break;
            }

           

            return Task.FromResult(true);
        }

        private void UpdateAuditStatus(OapAudit audit)
        {

            audit.Status = "Completed";

            OapAudit oAudit = OapAuditService.Get(audit.Id);
            Mapper.Map(audit, oAudit);

            var updatedAudit = OapAuditService.Update(oAudit);
        }
    }
}