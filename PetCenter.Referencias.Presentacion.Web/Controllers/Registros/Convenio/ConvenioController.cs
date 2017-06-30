using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Servicio;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Convenio;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ConvenioDescuento;
using PetCenter.Referencias.Presentacion.Web.Controllers.Comun;
using PetCenter.Referencias.Presentacion.Web.Helpers.Extensiones;
using PetCenter.Referencias.Presentacion.Web.Helpers.Mvc;
using PetCenter.Referencias.Presentacion.Web.Models.Registros.Convenio;
using PetCenter.Referencias.Presentacion.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PetCenter.Referencias.Presentacion.Web.Controllers.Registros.Convenio
{
    public class ConvenioController : BaseController
    {
        // GET: Convenio
        public ActionResult Registrar(int? idSolicitud = null)
        {
            //Generamos la solicitud
            var solicitud = new RegistrarConvenioDto
            {
                Solicitud = _registrosServicio.SolicitudServicio.Buscar(idSolicitud.HasValue ? idSolicitud.Value : 0)
            };

            if (solicitud.Solicitud == null) solicitud = null;

            //Construimos el modelo
            var modelo = new ConvenioEditorModelo
            {
                Solicitud = solicitud.Solicitud
            };

            modelo.Convenio.FechaConvenio = DateTime.Now;
            modelo.Convenio.FechaVencimiento = DateTime.Now.AddDays(365);

            return View("_Registrar", modelo);
        }

        [HttpPost]
        public ActionResult Registrar(ConvenioEditorModelo editor)
        {
            string mensaje = string.Empty;

            var modelo = new RegistrarConvenioDto
            {
                Solicitud = editor.Solicitud,
                Convenio = editor.Convenio
            };

            modelo.Convenio.ListaConvenioDescuento = editor.Convenio.ListaConvenioDescuento == null ? new List<ConvenioDescuentoDto>() : editor.Convenio.ListaConvenioDescuento.ToList();
            modelo.Convenio.ListaConvenioServicio = editor.Convenio.ListaConvenioServicio.ToList();

            var resultado = _registrosServicio.ConvenioServicio.Registrar(modelo);
            if (resultado == -1)
                mensaje = MensajeMvc.MensajePeligro(Mensajes.ErrorGenerico, Util.ObtenerControllerName(Request), Util.ObtenerActionName(Request));
            else
            {
                var nroConvenio = Util.GenerarCodigo(resultado);
                Util.EnviarCorreo(modelo.Solicitud.CorreoRep, "Convenio", string.Format(Mensajes.ConvenioRegistrado, nroConvenio, editor.Convenio.FechaConvenio.Value.ToShortDateString()));
                mensaje = MensajeMvc.MensajeSatisfactorio(Mensajes.ConvenioRegistrado, nroConvenio, editor.Convenio.FechaConvenio.Value.ToShortDateString());
            }

            return RedirectToAction("Index", "Evaluacion", new { mensaje = mensaje, back = true });
        }

        #region JSONRESULT
        public JsonResult ObtenerServicio(int idServicio)
        {
            var resultado = _maestrosServicio.ServicioServicio.Buscar(idServicio);
            if (resultado == null) resultado = new ServicioDto();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}