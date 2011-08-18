using Core.Services;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;

namespace Core.Data.NHibernate
{
    public class NHibernateConfiguration
    {
        readonly ConfigurationService _configurationService;

        public NHibernateConfiguration(ConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(_configurationService.ConnectionString)
                    .AdoNetBatchSize(20)
                    .ShowSql())
                .Mappings(m =>
                    m.AutoMappings.Add(
                    AutoMap.AssemblyOf<NHibernateRepository>(new MyAutoConfig())
                    .UseOverridesFromAssemblyOf<NHibernateRepository>()
                    .Conventions.Add(
                        Table.Is(x => Inflector.Net.Inflector.Pluralize(x.EntityType.Name)),
                        PrimaryKey.Name.Is(x => "ID"),
                        ForeignKey.EndsWith("ID"),
                        ConventionBuilder.HasManyToMany.Always(x=>x.AsList()),
                        DefaultCascade.All(),
                        ConventionBuilder.Class.Always(x =>
                                    x.Schema(
                                        x.EntityType.Namespace == null || x.EntityType.Namespace.EndsWith("Domain") ?
                                        "dbo" : x.EntityType.Namespace.Substring(x.EntityType.Namespace.LastIndexOf(".")))))))
                .ExposeConfiguration(cfg => Configuration = cfg)
                .BuildSessionFactory();
        }

        public Configuration Configuration { get; set; }

        public class MyAutoConfig : DefaultAutomappingConfiguration
        {
            public override bool IsId(FluentNHibernate.Member member)
            {
                return member.Name == "ID";
            }

            public override bool ShouldMap(System.Type type)
            {
                return type.Namespace.Contains("Domain");
            }

            public override bool ShouldMap(FluentNHibernate.Member member)
            {
                return member.IsProperty;
            }
        }
    }

    //public class ManyToManyConvention : IHasManyToManyConvention
    //{
    //    public void Apply(IManyToManyCollectionInstance instance)
    //    {
    //        instance.AsList();
    //    }
    //}
}