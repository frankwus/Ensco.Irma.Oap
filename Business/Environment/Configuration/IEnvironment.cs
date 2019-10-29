using SimpleInjector;

namespace Ensco.Irma.Framework.Configuration
{
    public interface IEnvironment
    {
        IFrameworkConfiguration Configuration { get; set; }

        Container Container { get; set; }

    }
}
