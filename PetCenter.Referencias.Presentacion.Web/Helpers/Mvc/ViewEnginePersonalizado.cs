using System.Web.Mvc;

namespace PetCenter.Referencias.Presentacion.Web.Helpers.Mvc
{
    public class ViewEnginePersonalizado : RazorViewEngine
    {
        public ViewEnginePersonalizado()
        {
            var viewLocations = new[] { 
            /** Controladores Vista**/            
            "~/Views/Comun/Inicio/{0}.cshtml",
             "~/Views/Comun/{1}/{0}.cshtml",
            "~/Views/Comun/{0}.cshtml",
 
            /** Controladores Vista por módulo**/            
            "~/Views/Seguridad/{1}/{0}.cshtml",            
            "~/Views/Maestros/{1}/{0}.cshtml",
            "~/Views/Configuraciones/{1}/{0}.cshtml",
            "~/Views/Registros/{1}/{0}.cshtml",
            };

            this.PartialViewLocationFormats = viewLocations;
            this.ViewLocationFormats = viewLocations;
        }

    }
}