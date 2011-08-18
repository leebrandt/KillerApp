using Core.Services;
using FakeItEasy;
using Machine.Specifications;

namespace Specifications.Integration
{
    [Subject("999 - Persistence")]
    public class When_establishing_a_connection_to_storage : With_a_persistence_context
    {
        Because of = () => _sessionFactory = _configuration.CreateSessionFactory();

        It should_get_the_location_of_storage_from_configuration = () =>
            A.CallTo(() => _configService.ConnectionString).MustHaveHappened();

        It should_connect_successfully = () =>
            _sessionFactory.OpenSession().IsConnected.ShouldBeTrue();
    }

    
    [Subject("999 - Configuration")]
    public class When_getting_the_location_of_storage_from_configuration
    {
        Establish context = () =>
        {
            _configSvc = new WebConfigurationService();
        };

        Because of = () => _cnxString = _configSvc.ConnectionString;

        It should_return_the_connection_information = () =>
            _cnxString.ShouldNotBeEmpty();

        static WebConfigurationService _configSvc;
        static string _cnxString;
    }
}