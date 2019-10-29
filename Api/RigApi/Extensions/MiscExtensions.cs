
using System;
using System.Activities;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Rig.Extensions
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Interfaces.Services.Oap;
    using Ensco.Irma.Interfaces.Services.Security;
    using Ensco.Irma.Interfaces.Services.Workflow;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Models.Domain.Security;
    using Ensco.Irma.Models.Domain.Workflow;

    public static class MiscExtensions
    {
        public static Activity GetActivity(this Workflow workflow, Guid rigChecklistId)
        {
            var activityhandle = Activator.CreateInstance(workflow.Assembly, workflow.Type);
            var activity = (Activity)activityhandle.Unwrap();
            activity.DisplayName = $"{workflow.Name}_{rigChecklistId}";

            return activity;
        }

        public static void StartWorkflow(this RigOapChecklist rigOapChecklist, IRigOapChecklistWorkflowService rigOapChecklistWorkflowService, IWorkflowEngineService workflowEngineService, IWorkflowService workflowService, IPeopleService peopleService, ILog log, int ownerId)
        {
            var workflow = workflowService.GetActiveWorkflow(rigOapChecklist.OapChecklist.OapType.ChecklistLayoutId.Value);

            //Create the Workflow Activity
            var workflowActivity = workflow.GetActivity(rigOapChecklist.Id);

            //Create the RigOapChecklistWorkflow instance
            var rigChecklistWorkflow = new RigOapChecklistWorkflow(rigOapChecklist)
            {
                Name = $"Workflow Instance: {workflow.Name}",
                Workflow = workflow
            };

            var version = new Version(workflow.Major, workflow.Minor);
            //Start the Workflow Instance and All the store the instance details

            //var login =  Thread.CurrentPrincipal.Identity.Name;
            workflowEngineService.Start(workflowActivity, version, rigChecklistWorkflow);

            rigChecklistWorkflow.Id = rigOapChecklistWorkflowService.Add(rigChecklistWorkflow);

            //var owner = PeopleService.GetByLogin(login);
            //var owner = peopleService.Get(ownerId);

            //Get the Current Principal And Assign Him to Workflow to 
            workflowEngineService.Process(workflowActivity, version, rigChecklistWorkflow, new AssignmentTransition("Assigned"), new AssignmentRequest() { Users = new List<AssignedUser> { new AssignedUser() { UserId = ownerId,  Role = "Owner" } } });

        }

        public static void ProcessWorkflow(this RigOapChecklist rigOapChecklist, IRigOapChecklistWorkflowService rigOapChecklistWorkflowService, IWorkflowEngineService workflowEngineService, IWorkflowService workflowService, WorkflowTransition transition, WorkflowRequest request, ILog log)
        {
            var workflow = workflowService.GetActiveWorkflow(rigOapChecklist.OapChecklist.OapType.ChecklistLayoutId.Value);

            //Create the Workflow Activity
            var workflowActivity = workflow.GetActivity(rigOapChecklist.Id);

            if (workflowActivity == null)
            {
                log.Error($" Workflow Activity was not found for checklist : { rigOapChecklist.Id}");
                return;
            }

            //Create the RigOapChecklistWorkflow instance
            var rigChecklistWorkflow = rigOapChecklistWorkflowService.GetWorkflowByChecklist(rigOapChecklist.Id);

            if (rigChecklistWorkflow == null)
            {
                log.Error($" Workflow instance was not found for checklist : { rigOapChecklist.Id}");
                return;
            }

            var version = new Version(workflow.Major, workflow.Minor);
            //Start the Workflow Instance and All the store the instance details 

            //Get the Current Principal And Assign Him to Workflow to 
            workflowEngineService.Process(workflowActivity, version, rigChecklistWorkflow, transition, request);
        }
    }
}
