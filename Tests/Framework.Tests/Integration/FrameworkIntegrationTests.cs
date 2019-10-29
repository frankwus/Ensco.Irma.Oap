using System;
using Ensco.Irma.Framework.Configuration; 
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ensco.Irma.Framework.Tests
{
    [TestClass]
    public class FrameworkTests
    {
        [TestMethod]
        public void ConfigurationEnvironmentTest()
        {
            var env = FrameworkEnvironment.Configure();

            Assert.IsNotNull(env);
        }

        [TestMethod]
        public void CheckDataConfigurationTest()
        {
            var env = FrameworkEnvironment.Configure();

            Assert.IsNotNull(env); 

            var dbServer = "(local)";
            var databaseName = "Test";
            var dbLogin = "sa";
            var dbPassword = "helloworld123";

            var config = env.Configuration;
            Assert.IsNotNull(config);
            
            Assert.AreEqual(config.Data.Server, dbServer, true);
            Assert.AreEqual(config.Data.Database, databaseName, true);
            Assert.AreEqual(config.Data.Username, dbLogin, true);
            Assert.AreEqual(config.Data.Password, dbPassword, true); 

        }

        [TestMethod]
        public void CheckConnectionStringTest()
        {
            var env = FrameworkEnvironment.Configure();

            Assert.IsNotNull(env);
            Assert.IsNotNull(env.Configuration);
            Assert.IsNotNull(env.Configuration.Data);

            var actualConnection = "Server=(local);Database=test;User Id=sa;Password=helloWorld123;multipleactiveresultsets=True;";

            var connection = env.Configuration.GetConnectionString();
             
            Assert.IsFalse(String.IsNullOrEmpty(connection));

            Assert.AreEqual(connection, actualConnection, true); 
        }
    }
}
