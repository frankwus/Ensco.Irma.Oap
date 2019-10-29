using Ensco.Environment.Data;
using System.Configuration;

namespace Ensco.Irma.Framework.Configuration
{ 
    public interface IFrameworkConfiguration: IConfigurationSectionHandler
    {
        string Name { get; set; }

        DataConfiguration Data { get; }

        string GetConnectionString(bool useMaster = false);
    }
}
