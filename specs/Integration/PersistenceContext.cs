using Core.Data.NHibernate;
using Core.Services;
using FakeItEasy;
using Machine.Specifications;
using NHibernate;

namespace Specifications.Integration
{
    public class With_a_persistence_context
    {
        protected static ConfigurationService _configService;
        protected static NHibernateConfiguration _configuration;
        protected static ISessionFactory _sessionFactory;

        Establish context = () =>
        {
            _configService = A.Fake<ConfigurationService>();
            A.CallTo(()=>_configService.ConnectionString).Returns(@"data source=.;initial catalog=KillerApp;Integrated Security=SSPI;");
            _configuration = new NHibernateConfiguration(_configService);
        };
    }
}