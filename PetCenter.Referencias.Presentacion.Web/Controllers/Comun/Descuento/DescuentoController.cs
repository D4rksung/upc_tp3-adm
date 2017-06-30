using PetCenter.Referencias.Presentacion.Web.Models.Comun.Descuento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetCenter.Referencias.Presentacion.Web.Controllers.Comun.Descuento
{
    public class DescuentoController : BaseController
    {
        public ActionResult BuscadorIndex()
        {

            var modelo = new DescuentoEditorModelo();

            return PartialView("_BuscadorIndex", modelo);
        }
    }
}