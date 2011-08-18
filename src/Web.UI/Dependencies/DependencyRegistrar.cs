using StructureMap;

namespace Web.UI.Dependencies
{
    public class DependencyRegistrar
    {
        public static void RegisterDependencies()
        {
            ObjectFactory.Initialize(x => x.Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.LookForRegistries();
            }));
        }
    }
}