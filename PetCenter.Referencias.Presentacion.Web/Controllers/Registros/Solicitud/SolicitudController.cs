using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud;
using PetCenter.Referencias.Presentacion.Web.Controllers.Comun;
using PetCenter.Referencias.Presentacion.Web.Helpers.Mvc;
using PetCenter.Referencias.Presentacion.Web.Models.Registros.Solicitud;
using PetCenter.Referencias.Presentacion.Web.Resources;
using System;
using System.Web.Mvc;

namespace PetCenter.Referencias.Presentacion.Web.Controllers.Registros.Solicitud
{
    public class SolicitudController : BaseController
    {
        // GET: Solicitud
        public ActionResult Index(int? idSolicitud = null)
        {

            var modelo = new SolicitudEditorModelo
            {
                Solicitud = new SolicitudDto() { FechaSolicitud = DateTime.Now, FechaVencimiento = DateTime.Now }
            };

            ViewBag.TiposDocumento = _maestrosServicio.TipoDocumentoServicio.Listar();
            ViewBag.Monedas = _maestrosServicio.MonedaServicio.Listar();
            ViewBag.Bancos = _maestrosServicio.BancoServicio.Listar();

            if (idSolicitud.HasValue)
            {
                if (idSolicitud == -1)
                {
                    modelo.AsignarMensaje(MensajeMvc.MensajeError(Mensajes.SolicitudError));
                }
                else
                {
                    modelo.AsignarMensaje(MensajeMvc.MensajeSatisfactorio(string.Format(Mensajes.SolicitudRegistrada, idSolicitud)));
                }
            }

            // modelo.AsignarMensaje(mensaje);

            return View("_Registrar", modelo);
        }

        [HttpPost]
        public ActionResult Registrar(RegistrarSolicitudDto registro)
        {
            var respuesta = _registrosServicio.SolicitudServicio.Registrar(registro);

            return RedirectToAction("Index", "Solicitud", new { idSolicitud = respuesta });
        }
    }
}