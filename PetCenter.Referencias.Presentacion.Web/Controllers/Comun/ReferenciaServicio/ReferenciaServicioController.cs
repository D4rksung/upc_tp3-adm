using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ConvenioServicio;
using PetCenter.Referencias.Presentacion.Web.Models.Comun.ReferenciaServicio;
using System.Web.Mvc;

namespace PetCenter.Referencias.Presentacion.Web.Controllers.Comun.ReferenciaServicio
{
    public class ReferenciaServicioController : BaseController
    {
        public ActionResult BuscadorIndex(int idConvenio)
        {
            ViewBag.ConvenioServicios = _maestrosServicio.ConvenioServicioServicio.Listar(idConvenio);

            var modelo = new ReferenciaServicioEditorModelo();

            return PartialView("_BuscadorIndex", modelo);
        }

        public JsonResult ObtenerConvenioServicio(int idServicio, int nroConvenio)
        {
            var resultado = _maestrosServicio.ConvenioServicioServicio.Buscar(idServicio, nroConvenio);
            if (resultado == null) resultado = new ConvenioServicioDto();
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }
    }
}