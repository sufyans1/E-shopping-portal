using System.Web.Mvc;
using System.Web.Routing;

namespace E_shopping_portal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "EshoppingPortal", action = "index", id = UrlParameter.Optional }
            );
        }
    }
}
