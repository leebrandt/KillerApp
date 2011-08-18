using System.Web.Routing;
using Machine.Specifications;
using Web.UI;

namespace Specifications
{
    public class With_main_site_routes_registered
    {
        Establish context = () =>
            {
                RouteTable.Routes.Clear();
                MvcApplication.RegisterRoutes(RouteTable.Routes);
            };
    }
}