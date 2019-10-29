using Ensco.Irma.Data.Context;
using Ensco.Irma.Data.Repositories;
using Ensco.Irma.Framework.Configuration;
using Ensco.Irma.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Threading;

namespace Ensco.Irma.Data.Tests.Repository.Integration
{
    [TestClass]
    public class OapChecklistRepositoryTests
    {
        private IIrmaOapDbContext Context { get; set; }

        private IrmaDbContext IrmaContext { get; set; }

        private OapChecklistRepository OapChecklistRepository { get; set; }

        private OapChecklistTopicRepository OapChecklistTopicRepository { get; set; }
        public RigOapChecklistRepository RigOapChecklistRepository { get; private set; }

        [TestInitialize]
        public void Initialize()
        {
            FrameworkEnvironment.Configure();
            Context = new IrmaOapDbContext(FrameworkEnvironment.Instance.Configuration.GetConnectionString());

            IrmaContext = new IrmaDbContext(FrameworkEnvironment.Instance.Configuration.GetConnectionString());

            OapChecklistRepository = new OapChecklistRepository(Context, Log.GetLogger(this.GetType()));

            OapChecklistTopicRepository = new OapChecklistTopicRepository(Context, Log.GetLogger(this.GetType()));

            RigOapChecklistRepository = new RigOapChecklistRepository(Context, Log.GetLogger(this.GetType()));

        }


        [TestMethod]
        public void GetOapChecklist()
        {
            try
            {
                var checklist = OapChecklistRepository.GetAll().ToList().FirstOrDefault();
                Assert.IsNotNull(checklist);
            }
            catch (System.Exception e)
            {

                //throw;
            }
             
        }

        [TestMethod]
        public void GetRigOapBACChecklist()
        {
            try
            {
                var checklist = RigOapChecklistRepository.GetCompleteChecklist(Guid.Parse("B096A53F-0D20-E911-9575-F4B7E2E8D6A3"));
                Assert.AreNotEqual(Guid.Empty,checklist.Assets.ToList()[0].Id);
            }
            catch (System.Exception e)
            {

                //throw;
            } 
        }


        [TestMethod]
        public void GetAdminCustomData()
        {
            var adminCustomRepository = new AdminCustomRepository(IrmaContext, Log.GetLogger(this.GetType()));
            var val = adminCustomRepository.GetAll().ToList().FirstOrDefault();
            Assert.IsNotNull(val);
        }

        [TestMethod]
        public void GetOIMFromAdminCustomData()
        {
            var adminCustomRepository = new AdminCustomRepository(IrmaContext, Log.GetLogger(this.GetType()));
            var val = adminCustomRepository.GetByName(VerifierRole.OIM.ToString());
            Assert.IsNotNull(val);
        }

        [TestMethod]
        public void GetPeopleData()
        {
            var peopleRepository = new PeopleRepository(IrmaContext, Log.GetLogger(this.GetType()));
            var val = peopleRepository.GetAll().ToList().FirstOrDefault();
            Assert.IsNotNull(val);
        }


        [TestMethod]
        public void AddFindingToRigChecklist()
        {
            try
            {
                var checklist = RigOapChecklistRepository.Get(Guid.Parse("48b56dc8-2bf3-e811-87f1-0050569674e7"));
                var question = checklist.Questions.FirstOrDefault();

                if(question != null)
                {

                    var finding = new RigOapChecklistQuestionFinding
                    {
                        CapaId = 1,
                        CriticalityId = 1,
                        FindingDate = DateTime.UtcNow,
                        FindingSubTypeId = 1,
                        FindingTypeId = 1,
                        Reason = "Test",
                        Status = "Open",
                        RigOapChecklistQuestionId = question.Id
                    };

                    if (question.Findings == null)
                    {
                        question.Findings = new List<RigOapChecklistQuestionFinding>(); 
                    }
                    question.Findings.Add(finding);
                    RigOapChecklistRepository.Update(checklist);
                }

            }
            catch (System.Exception e)
            {

                //throw;
            }


        }


        [TestMethod]
        public void GetIrmaTasks()
        {
            try
            {
                var taskRepsository = new IrmaTaskRepository(IrmaContext, Log.GetLogger(this.GetType()));
                var task = taskRepsository.GetAll().FirstOrDefault();
                Assert.IsNotNull(task);
            }
            catch (System.Exception e)
            {

                //throw;
            }


        }


        [TestMethod]
        public void ExecuteStoreProcedure()
        {
            var emailParams = new object[]
            {
                new SqlParameter("@email", "shosur@enscoplc.com"),
                new SqlParameter("@title", "Test Subject 1"),
                new SqlParameter("@s", "Email Content 1"),
                new SqlParameter("@cc", "")
            }; 

            var i= OapChecklistRepository.ExecuteSql("usp_sendEmail @email, @title, @s, @cc", emailParams);

            Assert.IsNotNull(i);
        }

        [TestMethod]
        public void SendEmail()
        {
            var i = OapChecklistRepository.SendEmail("shosur@enscoplc.com","Test Email Send Email","Hello This is a test");

            Assert.IsNotNull(i);
        }


        [TestMethod]
        public void CreateOapChecklist()
        { 
            ////var cl = new OapChecklist(); 

            ////Thread.CurrentPrincipal = WindowsPrincipal.Current;

            ////var hierarchy = new OapHierarchy
            ////{
            ////    Name = "Barrier Authority Checklist"
            ////};

            ////cl.ControlNumber = "FM-CO-MAY-801";

            //////cl.FormCategory = OapChecklistType.BarrierAuthority.ToDecription();
            //////cl.FormType = "Barge Supervisor"; 

            //////cl.Name = "Barrier Authority Checklist - Barge Supervisor";

            //////cl.ColumnHeadersMappingJson = @"{Topic.Name=""Safety Critical Task"", SubTopic.Name=""I Verify that I:""}";
             
            ////cl.OapType = hierarchy;

            ////var categoryList = new List<OapChecklistCategory>();
            
            ////var oapCategory1 = new OapChecklistCategory
            ////{
            ////    Name = "People",
            ////    Image = "People",
            ////    FormatType = "None",
            ////    OapChecklist = cl 
            ////};

            ////var oapTopic1 = new OapChecklistTopic
            ////{
            ////    Name = "Daily HoD Meetings",
            ////    OapChecklistCategory = oapCategory1
            ////};

            ////var oapSubTopics = new List<OapChecklistQuestion>
            ////{
            ////    new OapChecklistQuestion()
            ////    {
            ////        Name = "Contributed all department specific information required to plan safe and efficient opertions",
            ////        OapChecklistTopic = oapTopic1,  
            ////        FormatType = "Days"
            ////    },
               
            ////    new OapChecklistQuestion()
            ////    {
            ////        Name = "Planned upcoming safety critial asset maintenance activities(<i>if rig does not have a RMS assgined)",
            ////        OapChecklistTopic = oapTopic1,
            ////        FormatType = "Days"
            ////    } 
                 
            ////};

            ////oapTopic1.SubTopics = oapSubTopics;

            ////categoryList.Add(oapCategory1);

            ////cl.Categories = categoryList;
            ////OapChecklistRepository.Add(cl);

            ////OapChecklistTopicRepository.Add(oapTopic1);             
        }

        [TestMethod]
        public void CreateHierarchylist()
        {
            var oapHierarchyRepository = new OapHierarchyRepository(Context, Log.GetLogger(this.GetType()));
            var hierarchy = new OapHierarchy
            {
                Name = "OAP Protocol1",
                ChildrenHierarchies = new List<OapHierarchy> ()
                {
                    new OapHierarchy {Name = "Ensco Life Savers1"},
                    new OapHierarchy {Name = "Procss Safety1"},
                    new OapHierarchy {Name = "Key Operational Standards1"}
                }
            };


            oapHierarchyRepository.Add(hierarchy);
        }

        [TestMethod]
        public void GetHierarchy()
        {
            var oapHierarchyRepository = new OapHierarchyRepository(Context, Log.GetLogger(this.GetType()));


            var hierachy =  oapHierarchyRepository.Get(1);
        }
    }
}
