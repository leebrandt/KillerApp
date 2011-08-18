using Core.Services;
using StructureMap.Configuration.DSL;

namespace Web.UI.Dependencies
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            For<ConfigurationService>().Use<WebConfigurationService>();
        }
    }
}