using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig.Workflow
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Interfaces.Services.Oap;
    using Ensco.Irma.Interfaces.Services.Security;
    using Ensco.Irma.Interfaces.Services.Workflow;
    using Ensco.Irma.Models.Domain.Workflow;
    using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Workflow;
    using Ensco.Irma.Oap.Api.Rig.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProcessRigOapChecklistWokflowHandler : IRequestHandler<ProcessRigOapChecklistWorflowRequest, bool>
    {
        public IRigOapChecklistService RigOapChecklistService { get; }

        private IRigOapChecklistWorkflowService RigOapChecklistWorkflowService { get; set; }

        public IWorkflowEngineService WorkflowEngineService { get; }

        public IPeopleService PeopleService { get; }

        public ILog Log { get; }

        private IWorkflowService WorkflowService { get; set; }

        public ProcessRigOapChecklistWokflowHandler(IRigOapChecklistService rigOapChecklistService, IRigOapChecklistWorkflowService rigOapChecklistWorkflowService, IWorkflowService workflowService, IWorkflowEngineService workflowEngineService, IPeopleService peopleService, ILog log)
        {
            WorkflowService = workflowService;
            RigOapChecklistService = rigOapChecklistService;
            WorkflowEngineService = workflowEngineService;
            RigOapChecklistService = rigOapChecklistService;
            RigOapChecklistWorkflowService = rigOapChecklistWorkflowService;
            PeopleService = peopleService;
            Log = log;
        }

        Task<bool> IRequestHandler<ProcessRigOapChecklistWorflowRequest, bool>.Handle(ProcessRigOapChecklistWorflowRequest request, CancellationToken cancellationToken)
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

            //WorkflowTransition workflowTransition = null;
            //WorkflowRequest workflowRequest = null;

            //switch (request.Transition.ToLower())
            //{
            //    case "sign": 
            //        workflowTransition = new SignTransition(request.Transition);
            //        var signinputs = new Dictionary<string, object>();
            //        signinputs.Add("Verifier", request.UserId);
            //        workflowRequest = new SignRequest(signinputs);
            //        break;
            //    case "approve":
            //    case "review":
            //        workflowTransition = new ApprovalTransition(request.Transition);
            //        var approvalinputs = new Dictionary<string, object>();
            //        approvalinputs.Add("Verifier", request.UserId);
            //        workflowRequest = new ApprovalRequest(approvalinputs);
            //        break;
            //    case "reject":
            //        workflowTransition = new RejectionTransition(request.Transition);
            //        var rejectinputs = new Dictionary<string, object>();
            //        rejectinputs.Add("Verifier", request.UserId);
            //        workflowRequest = new RejectionRequest(request.Comment, request.Comment, rejectinputs);
            //        break;
            //    default:
            //        return Task.FromResult(false); 
            //}

            //existingRigChecklist.ProcessWorkflow(RigOapChecklistWorkflowService, WorkflowEngineService, WorkflowService, workflowTransition, workflowRequest, Log);
             
            return Task.FromResult(true);
        }
    }
}