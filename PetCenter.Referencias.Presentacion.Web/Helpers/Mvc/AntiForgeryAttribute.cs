using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace PetCenter.Referencias.Presentacion.Web.Helpers.Mvc
{
    /// <summary>
    /// Atributo contra la falsificación solo para POST
    /// </summary>
    public class AntiForgeryAttribute : IAuthorizationFilter
    {
        #region VARIABLES

        ///// <summary>
        ///// Interface al servicio con métodos Comunes.
        ///// </summary>
        //private readonly SeguridadServicio _seguridadServicio;

        #endregion

        public AntiForgeryAttribute()
        {
            //_seguridadServicio = SeguridadServicio.ObtenerServicio();
        }

        /// <summary>
        /// Sobrescribiendo el método de autorización
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //    var flag = AdministradorSesion.SesionActiva;
            //    var controler = filterContext.RouteData.Values["controller"];
            //    var accion= filterContext.RouteData.Values["action"];

            //    if (controler.Equals("Inicio") && accion.Equals("Login")) return;

            //    if (controler.Equals("Inscripciones") && accion.Equals("RegistroLogin")) return;
            //    if (controler.Equals("Persona") && accion.Equals("RegistroUsuario")) return;
            //    if (controler.Equals("Persona") && accion.Equals("ValidarCorreoExistente")) return;
            //    if (controler.Equals("Persona") && accion.Equals("Recuperar")) return;
            //    if (controler.Equals("Persona") && accion.Equals("RecuperarPassword")) return;
            //    if (controler.Equals("Persona") && accion.Equals("UbigeoProvincia")) return;
            //    if (controler.Equals("Persona") && accion.Equals("Ubigeo")) return;
            //    if (controler.Equals("Persona") && accion.Equals("ConsultaPersonaFN")) return;
            //    if (controler.Equals("Persona") && accion.Equals("Agregar")) return;
            //    if (controler.Equals("Persona") && accion.Equals("ConfirmacionRU")) return;
            //    if (controler.Equals("Usuario") && accion.Equals("Activar")) return;

            //    if (!flag && !controler.Equals("Inicio") && !accion.Equals("Login"))
            //    {
            //        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Inicio", action = "Login" }));
            //        filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
            //    }

            //    if (filterContext.RequestContext.HttpContext.Request.HttpMethod != "POST") return;

            //    if (filterContext.RequestContext.HttpContext.User.Identity.AuthenticationType=="Federation")
            //    {
            //        if (filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated)
            //        {
            //            AdministradorSesion.SesionActiva = true;
            //            AdministradorSesion.Tipo = "Office365";
            //            AdministradorSesion.Correo = filterContext.RequestContext.HttpContext.User.Identity.Name;

            //            return;
            //        }
            //    }

            //    if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(NoAntiForgeryCheckAttribute), true).Length > 0) return;

            //    new ValidateAntiForgeryTokenAttribute().OnAuthorization(filterContext);
        }

    }

    /// <summary>
    /// Para no solicitar atributo contra falsificación
    /// </summary>
    public class NoAntiForgeryCheckAttribute : Attribute { }

}