using System.Configuration;
using System.Web;
using System.Web.Security;

namespace PetCenter.Referencias.Presentacion.Web.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class AdministradorSesion
    {
        /// <summary>
        /// SesionActiva
        /// </summary>
        public static bool SesionActiva
        {
            set
            {
                HttpContext.Current.Session["SesionActiva"] = value;
                HttpContext.Current.Session.Timeout = 60000;
            }
            get
            {
                if (HttpContext.Current.Session["SesionActiva"] == null) return false;
                return bool.Parse(HttpContext.Current.Session["SesionActiva"].ToString());
            }
        }

        /// <summary>
        /// SesionActiva
        /// </summary>
        public static bool SeleccioneRol
        {
            set
            {
                HttpContext.Current.Session["SeleccioneRol"] = value;
            }
            get
            {
                if (HttpContext.Current.Session["SeleccioneRol"] == null) return false;
                return bool.Parse(HttpContext.Current.Session["SeleccioneRol"].ToString());
            }
        }

        public static void CerrarSession()
        {
            HttpContext.Current.Session.Clear();
            FormsAuthentication.SignOut();

            HttpContext.Current.User = null;
            HttpContext.Current.Session.Abandon();

        }
    }
}