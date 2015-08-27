using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Zealous
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapHttpRoute(
                name: "OneLevelNested",
                routeTemplate: "api/users/{userId}/pets/{petId}",
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) },
                defaults: new { controller = "Users", action = "GetUserPets", petId = RouteParameter.Optional, }
                );

        }
    }
}
