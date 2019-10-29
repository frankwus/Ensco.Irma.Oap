using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Interfaces.Services.Security;
using Ensco.Irma.Interfaces.Services.Workflow;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.WorkFlow;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Collections.Generic;
using Ensco.Irma.Models.Domain.Oap.Audit;



namespace Ensco.Irma.Oap.Api.Corp.Handlers.OapAudits
{
    
    public class StartOapAuditWorkFlowHandler: IRequestHandler<StartOapAuditWorkFlowRequest, bool>
    {

        public IRigOapChecklistService RigOapChecklistService { get; }

        private IRigOapChecklistWorkflowService RigOapChecklistWorkflowService { get; set; }

        public IWorkflowEngineService WorkflowEngineService { get; }

        public IPeopleService PeopleService { get; }

        public IOapAuditService OapAuditService { get; }

        public ILog Log { get; }
        private IWorkflowService WorkflowService { get; set; }

        private IMapper Mapper { get; set; }

        public StartOapAuditWorkFlowHandler(IRigOapChecklistService rigOapChecklistService, IRigOapChecklistWorkflowService rigOapChecklistWorkflowService, IWorkflowService workflowService, IWorkflowEngineService workflowEngineService, IPeopleService peopleService, IOapAuditService auditService, ILog log, IMapper mapper)
        {
            WorkflowService = workflowService;
            RigOapChecklistService = rigOapChecklistService;
            WorkflowEngineService = workflowEngineService;
            RigOapChecklistWorkflowService = rigOapChecklistWorkflowService;
            PeopleService = peopleService;
            OapAuditService = auditService;
            Log = log;
            Mapper = mapper;
        }



        Task<bool> IRequestHandler<StartOapAuditWorkFlowRequest, bool>.Handle(StartOapAuditWorkFlowRequest request, CancellationToken cancellationToken)
        {
            var existingRigChecklist = RigOapChecklistService.Get(request.RigChecklistId);
            var chklist = new List<RigOapChecklist>();
            if (existingRigChecklist == null)
            {
                return Task.FromResult(false);
            }


            RigOapChecklistWorkflowService.StartChecklistWorkFlow(existingRigChecklist);
            if(request.Audit.OapAuditProtocols !=null && request.Audit.OapAuditProtocols.Count > 0)
            {
                foreach (var s in request.Audit.OapAuditProtocols)
                {
                    chklist.Add(s.RigOapChecklist);
                }
            }
            UpdateAuditStatus(request.Audit);
            RigOapChecklistWorkflowService.UpdateRigChecklistsStatus(chklist);
            return Task.FromResult(true);
        }

       private void UpdateAuditStatus(OapAudit audit)
        {

            audit.Status = "Pending";

            OapAudit oAudit = OapAuditService.Get(audit.Id);
            Mapper.Map(audit, oAudit);

            var updatedAudit = OapAuditService.Update(oAudit);
        }
    }
}