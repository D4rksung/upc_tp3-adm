using PetCenter.Referencias.Presentacion.Web.Controllers.Comun;
using System.Web.Mvc;

namespace PetCenter.Referencias.Presentacion.Web.Controllers.Reportes
{
    public class ReportesController : BaseController
    {
        // GET: Reportes
        public ActionResult Index()
        {
            return View("_Reportes");
        }


        public ActionResult ObtenerTotalAtencionesPorMes()
        {
            var resultado = _registrosServicio.AtencionServicio.ObtenerTotalAtencionesPorMes();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtenerTotalConvenio()
        {
            var resultado = _registrosServicio.LiquidacionServicio.ObtenerTotalPorConvenio();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtenerServiciosReferencia()
        {
            var resultado = _registrosServicio.AtencionServicio.ObtenerServiciosPorAtencion();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtenerEspecies()
        {
            var resultado = _registrosServicio.ReferenciaServicio.ObtenerEspecies();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtenerRazasPerros()
        {
            var resultado = _registrosServicio.ReferenciaServicio.ObtenerRaza(1);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtenerRazasGatos()
        {
            var resultado = _registrosServicio.ReferenciaServicio.ObtenerRaza(2);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}