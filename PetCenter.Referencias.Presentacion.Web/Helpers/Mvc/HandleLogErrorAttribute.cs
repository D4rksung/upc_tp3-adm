using System.Web.Mvc;
using PetCenter.Referencias.Presentacion.Web.Helpers.Extensiones;

namespace PetCenter.Referencias.Presentacion.Web.Helpers.Mvc
{
    /// <summary>
    /// Atributo de error personalizado
    /// </summary>
    public class HandleLogErrorAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// Sobrescribiendo método que lanza la excepción
        /// </summary>
        /// <param name="filterContext">filterContext</param>
        public override void OnException(ExceptionContext filterContext)
        {
            var controlador = (string)filterContext.RouteData.Values["controller"];
            var accion = (string)filterContext.RouteData.Values["action"];
            filterContext.Exception.CapturarError(controlador, accion);
            base.OnException(filterContext);
        }
    }
}