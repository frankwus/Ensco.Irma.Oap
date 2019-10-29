using SimpleInjector;
using System;
using System.Configuration;

namespace Ensco.Irma.Framework.Configuration
{
    public class FrameworkEnvironment : IEnvironment
    {
        private static object _lockObject = new object();
        public static FrameworkEnvironment Instance { get; set; } = new Lazy<FrameworkEnvironment>(() => Configure()).Value;

        public IFrameworkConfiguration Configuration { get; set; }

        public Container Container { get; set; }

        private FrameworkEnvironment(IFrameworkConfiguration configuration)
        {
            Configuration = configuration; 
        }


        /// <summary>
        /// Configures the <seealso cref="FrameworkEnvironment"/>
        /// </summary>
        public static FrameworkEnvironment Configure(IConfigurationSectionHandler configuration = null)
        {
            if (Instance == null)
            {
                lock (typeof(FrameworkEnvironment))
                {
                    try
                    {
                        //Load configuration from config file if not provided
                        configuration = configuration ?? (FrameworkConfiguration)ConfigurationManager.GetSection("Framework");

                        //Create environment and configure it.
                        var env = new FrameworkEnvironment((IFrameworkConfiguration)configuration);
                        env.ConfigureContainer();
                        return env;
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("Error configuring Environment: {0}", exception);
                        throw;
                    }
                }
            }

            return Instance;
        }

        private void ConfigureContainer()
        {
            if (Container == null)
            {
                Container = new Container();
            }
        }
    }
}
