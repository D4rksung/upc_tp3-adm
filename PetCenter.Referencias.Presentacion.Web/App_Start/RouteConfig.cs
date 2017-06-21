using System.Web.Mvc;
using System.Web.Routing;

namespace PetCenter.Referencias.Presentacion.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{accion}",
                defaults: new { controller = "Inicio", action = "Index", id = UrlParameter.Optional, accion = UrlParameter.Optional }
            );

        }
    }
}
