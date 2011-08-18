using System.Linq;
using Core.Data;
using Core.Data.NHibernate;
using NHibernate;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Web.UI.Dependencies
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            var pluginTypes = typeof(Repository).Assembly.GetTypes().Where(t => !t.Name.StartsWith("NHibernate") && t.Name.EndsWith("Repository"));
            foreach (var pluginType in pluginTypes)
            {
                var concreteType =
                    typeof(NHibernateRepository).Assembly.GetTypes()
                        .FirstOrDefault(t =>
                                        t.Name.StartsWith("NHibernate") &&
                                        t.Name.EndsWith("Repository") &&
                                        pluginType.IsAssignableFrom(t));

                if (concreteType != null)
                    For(pluginType).Use(concreteType);
            }

            For<ISessionFactory>().UseSpecial(
                x => x.ConstructedBy(
                    () => ObjectFactory.GetInstance<NHibernateConfiguration>()
                              .CreateSessionFactory()))
                .Singleton();
        }
    }
}