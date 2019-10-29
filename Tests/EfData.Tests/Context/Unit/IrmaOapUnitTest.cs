using System;
using Ensco.Irma.Models.Domain.IRMA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ensco.Data.Tests.Context.Unit
{
    [TestClass]
    public class IrmaOapUnitTest
    {
        [TestMethod]
        public void TestPobPersonnelCreate()
        {

            var pobM = new PobPersonnel();

            Assert.IsNotNull(pobM); 
        }


        [TestMethod]
        public void TestPobPersonnelEndDateTimeToNull()
        {
            var pobM = new PobPersonnel
            {
                EndDateTime = null
            };
            Assert.IsNotNull(pobM);
        }
    }
}
