using PetCenter.Referencias.Presentacion.Web.Models.Comun.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetCenter.Referencias.Presentacion.Web.Controllers.Comun.Servicio
{
    public class ServicioController : BaseController
    {

        public ActionResult BuscadorIndex()
        {

            ViewBag.Servicios = _maestrosServicio.ServicioServicio.Listar();

            var modelo = new ServicioEditorModelo();

            return PartialView("_BuscadorIndex", modelo);
        }
    }
}