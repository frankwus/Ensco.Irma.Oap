using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Ensco.Irma.Data.Repositories;
using Ensco.Irma.Models.Domain.IRMA;
using Ensco.Irma.Interfaces.Data.Repositories;

namespace Ensco.Data.Tests.Repository.Unit
{
    [TestClass]
    public class IrmaCapaRepositoryTests
    {
        Mock<IrmaCAPARepository> mock;

        [TestInitialize]
        public void Initialize()
        {
            mock = new Mock<IrmaCAPARepository>();
            
            
        }

        //[TestMethod]
        //public void CAPAsAreReturnedFromRepository()
        //{
        //    //int findingId = 1;            

        //    //mock.SetupGet(repo => repo.AllItems)
        //    //    .Returns((new List<IrmaCapa>() {
        //    //        new IrmaCapa() { Id = 1, ActionRequired = "CAPA01" }, new IrmaCapa() { Id=2,ActionRequired="CAPA02" } })
        //    //            .AsQueryable());

        //    //Assert.Equals(mock.Object.GetCAPAsByFindingsID(findingId).Count(), 2);
        //}
    }
}
