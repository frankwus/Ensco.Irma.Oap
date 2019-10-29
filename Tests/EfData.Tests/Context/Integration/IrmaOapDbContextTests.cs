using Ensco.Irma.Data.Context;
using Ensco.Irma.Framework.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Ensco.Irma.EfData.Tests.Context.Integration
{
    [TestClass]
    public class IrmaOapDbContextTests
    { 
        private IIrmaOapDbContext OapContext { get; set; }
        private IIrmaDbContext IrmaContext { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            FrameworkEnvironment.Configure();
            OapContext = new IrmaOapDbContext(FrameworkEnvironment.Instance.Configuration.GetConnectionString());
            IrmaContext = new IrmaDbContext(FrameworkEnvironment.Instance.Configuration.GetConnectionString());
        }


        [TestMethod]
        public void TestWorkflowContext()
        {
            var wk = OapContext.Workflows.ToList();

            Assert.IsNotNull(wk); 
        }

        [TestMethod]
        public void TestPeopleContext()
        {
            var people = IrmaContext.People.ToList();

            Assert.IsNotNull(people); 
        }

        [TestMethod]
        public void TestPobPersonnelContext()
        {
            var test = IrmaContext.PobPeople.ToList();

            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void TestPobPersonnelWithPersonContext()
        {
            var test = (from pp in IrmaContext.PobPeople
                       from p in IrmaContext.People
                        where pp.PobPersonId == p.Id  
                       select new { pp, p }).ToList();

            Assert.IsNotNull(test);
        }

         

        [TestMethod]
        public void TestRigContext()
        {
            var rigs = IrmaContext.Rigs.ToList();

            Assert.IsNotNull(rigs);
        }


        [TestMethod]
        public void TestOapHierarchyContext()
        {
            var oapH = OapContext.OapHierarchies.ToList();

            Assert.IsNotNull(oapH);
        }

        [TestMethod]
        public void TestOapChecklistQuestionTagContext()
        {
            var oapH = OapContext.OapChecklistQuestionTags.ToList();

            Assert.IsNotNull(oapH);
        }

        [TestMethod]
        public void TestRigOapChecklistQuestionRelatedSearchContext()
        {
            var oapH = OapContext.RigOapChecklistQuestions.ToList();

            Assert.IsNotNull(oapH);
        }
    }
}
