using PetCenter.Referencias.Presentacion.Web.App_Start;
using PetCenter.Referencias.Presentacion.Web.Helpers.Extensiones;
using PetCenter.Referencias.Presentacion.Web.Helpers.Mvc;
using PetCenter.Referencias.Presentacion.Web.Resources;
using System;
using System.Globalization;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PetCenter.Referencias.Presentacion.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {  /// <summary>
       /// Inicio de la aplicacion web
       /// </summary>
        protected void Application_Start()
        {
           
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ViewEnginePersonalizado());

            CultureInfo cultureInf = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            cultureInf.DateTimeFormat.ShortDatePattern = Formatos.FechaCorta;

            ModelBinders.Binders.Add(typeof(DateTime), new DateTimeBinder(cultureInf));
            ModelBinders.Binders.Add(typeof(DateTime?), new DateTimeBinder(cultureInf));
        }

        /// <summary>
        /// No se guardará cache de ninguna página
        /// </summary>
        protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }

        /// <summary>
        /// Genera de errores que pasan por Application_Error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            if (Server != null)
            {
                var controlador = "Desconocido";
                var accion = "Desconocido";
                try
                {
                    var path = Request.FilePath.Split('/');
                    controlador = path[1];
                    accion = path[2];
                }
                catch (Exception) { }

                Server.GetLastError().CapturarError(controlador, accion);
            }
        }
    }

    #region BINDERS

    /// <summary>
    /// Modelo del enlace de un parametro Request.DateTime; para mantener la localizacion actual.
    /// </summary>
    public class DateTimeBinder : IModelBinder
    {
        /// <summary>
        /// CultureInfo
        /// </summary>
        private CultureInfo _cultureInf;

        /// <summary>
        /// Construnctor por defecto
        /// </summary>
        /// <param name="cultureInf">cultureInf</param>
        public DateTimeBinder(CultureInfo cultureInf)
        {
            _cultureInf = cultureInf;
        }

        /// <summary>
        /// Método que realiza el enlace.
        /// </summary>
        /// <param name="controllerContext">controllerContext</param>
        /// <param name="bindingContext">bindingContext</param>
        /// <returns>date</returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            //value = new ValueProviderResult("01/01/2014 11:33 am", "01/01/2014 11:33 am", value.Culture);
            var date = value.ConvertTo(typeof(DateTime), _cultureInf);

            return date;
        }
    }

    #endregion
}
