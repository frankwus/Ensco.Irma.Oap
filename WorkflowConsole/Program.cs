using Ensco.Irma.Business.Workflow;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Data.Repositories;
using Ensco.Irma.Framework.Configuration;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Models.Domain.Security;
using Ensco.Irma.Models.Domain.Workflow;
using Ensco.Irma.Services.Workflow.Designers;
using System;
using System.Activities;
using System.Activities.XamlIntegration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xaml;

namespace Ensco.WorkflowConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FrameworkEnvironment.Configure();
            var context = new IrmaOapDbContext(FrameworkEnvironment.Instance.Configuration.GetConnectionString());

            var log = Ensco.Irma.Logging.Log.GetLogger(typeof(Program));

            //Activity activity = ActivityXamlServices.Load("TestWfActivity.xaml", new ActivityXamlServicesSettings { CompileExpressions = true });
           

            

            var rchl = new RigOapChecklistRepository(context, log);
            var oacpChl = new OapChecklistRepository(context, log);
            var rigR = new RigRepository(context, log);

            

            var rigChecklist = rchl.Get(Guid.Parse("407F66ED-82BB-E811-BA80-30E37A858A8A"));

            ProcessWorkflow(rigChecklist, log, context);
            /*
            if (rigChecklist == null)
            {
                var rig = rigR.Get(1);

                if (rig == null)
                {
                    var r = new Irma.Models.Domain.Oap.Rig()
                    {
                        Name = "Rig 1",
                        Description = "Test Rig 1",
                        RigNumber = "1",
                        StartDateTime = DateTime.Now.AddYears(-10),
                        EndDateTime = DateTime.MaxValue,

                    };

                    var rid = rigR.Add(r);
                    rig = rigR.Get(rid);
                }

                rigChecklist = new RigOapChecklist()
                {
                    OapChecklist = oacpChl.GetAll(DateTime.MinValue, DateTime.MaxValue).FirstOrDefault(),
                    Rig = rig
                };

                var id = rchl.Add(rigChecklist);
                rigChecklist = rchl.Get(id);
            }
            */
             AddWorkflow(rigChecklist, log, context);

            ProcessWorkflow(rigChecklist, log, context);

            Console.Write("Enter some value:");
            Console.ReadLine(); 
        }

        public static void AddWorkflow(RigOapChecklist rigOapChecklist, ILog log, IIrmaOapDbContext context)
        {
            var workflowActivity = new Genericlist() { DisplayName = $"Genericlist_{rigOapChecklist.Id}" };

            var activities = new List<Activity>(WorkflowInspectionServices.GetActivities(workflowActivity));

            var indent = 0;
            activities.ForEach((act) => Console.WriteLine("{0}{1}", new string(' ', indent), act.DisplayName));

            string serializedAB = ToXaml(activities[0]);
            var version = new Version(1, 0);
            var wfr = new WorkflowRepository(context, log);

            var workflow = wfr.GetActiveWorkflow(8);

            //var workflow = new Irma.Models.Domain.Workflow.Workflow();
            //workflow.Name = "BarrierAuthorityOIM";
            //workflow.Major = version.Major;
            //workflow.Minor = version.Minor;
            //workflow.Active = true;
            //workflow.ActivityXaml = ToXaml(workflowActivity);

            //var workflowType = workflowActivity.GetType();
            //workflow.Assembly = workflowType.Assembly.GetName().Name;
            //workflow.Type = workflowType.FullName;
             
            var workflowinstance = new RigOapChecklistWorkflow(rigOapChecklist)
            {
                Name = $"{workflow.Name} Instance",
                Workflow = workflow
            };

            var wfs = new WorkflowEngineService(log);
            var wfir = new RigOapChecklistWorkflowRepository(context, log);

            wfs.Start(workflowActivity, version, workflowinstance);

            wfir.Add(workflowinstance); 
        }

        public static string ToXaml(Activity activity)
        {
            var sBuilder = new StringBuilder(); 
            StringWriter tw = new StringWriter(sBuilder);
            XamlWriter xw = ActivityXamlServices.CreateBuilderWriter(new XamlXmlWriter(tw, new XamlSchemaContext()));
           
            using (xw)
            {  
                var activityBuilder =
                    new ActivityBuilder { Implementation = activity};
                XamlServices.Save(xw, activityBuilder); 
            }
            return sBuilder.ToString();
        }

        public static void ProcessWorkflow(RigOapChecklist rigOapChecklist, ILog log, IIrmaOapDbContext context)
        {
            var wfs = new WorkflowEngineService(log);
            var wfir = new RigOapChecklistWorkflowRepository(context, log);
            var peopler = new PeopleRepository(context, log); 

            var workflowActivity = new Genericlist() { DisplayName = $"Genericlist_{rigOapChecklist.Id}" };

            var workflowinstance = wfir.GetWorkflowByChecklist(rigOapChecklist.Id);

             
            var people = new List<Person>() { peopler.Get(rigOapChecklist.OwnerId) };

            var request = new AssignmentRequest() { Users = people };

            wfs.Process(workflowActivity, new Version(workflowinstance.Workflow.Major, workflowinstance.Workflow.Minor), workflowinstance, workflowinstance.Transition, request);
        }
    }
}
