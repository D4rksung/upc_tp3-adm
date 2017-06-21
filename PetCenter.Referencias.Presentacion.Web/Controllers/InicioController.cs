using PetCenter.Referencias.Presentacion.Web.Helpers;
using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace PetCenter.Referencias.Presentacion.Web.Controllers
{
    public class InicioController : Controller
    {
        #region PROPIEDADES                
        //public readonly ISrvSeguridad _seguridadServicio;
        #endregion

        #region CONSTRUCTOR        
        public InicioController()
        {
           // _seguridadServicio = new SrvSeguridadClient();
        }
        #endregion

        public ActionResult Index()
        {            
            return View("Inicio");
        }

        public ActionResult NoAutorizado()
        {
            return View("_NoAutorizado");
        }

    }
}