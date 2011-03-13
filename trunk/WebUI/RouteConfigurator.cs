using System.Web.Mvc;
using System.Web.Routing;

namespace Omu.ProDinner.WebUI
{
    public class RouteConfigurator
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("elmah.axd");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Dinner", action = "Index", id = UrlParameter.Optional } // Parameter defaults
                );
        }
    }
}