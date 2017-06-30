using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia;
using PetCenter.Referencias.Presentacion.Web.Controllers.Comun;
using PetCenter.Referencias.Presentacion.Web.Helpers.Extensiones;
using PetCenter.Referencias.Presentacion.Web.Helpers.Mvc;
using PetCenter.Referencias.Presentacion.Web.Models.Registros.Referencia;
using PetCenter.Referencias.Presentacion.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetCenter.Referencias.Presentacion.Web.Controllers.Registros.Referencia
{
    public class ReferenciaController : BaseController
    {
        // GET: Referencia
        public ActionResult Index(string mensaje = null)
        {

            var modelo = new ReferenciaEditorModelo();
            if (!string.IsNullOrEmpty(mensaje))
            {
                modelo.AsignarMensaje(mensaje);
            }

            return View("_Index", modelo);
        }

        public ActionResult ObtenerConvenio(ReferenciaEditorModelo model)
        {
            var mensaje = string.Empty;
            var convenio = _registrosServicio.ConvenioServicio.Buscar(model.Convenio.NroConvenio);

            if (convenio == null)
            {
                mensaje = MensajeMvc.MensajeAdvertencia(Mensajes.ConvenioNoEncontrado);
                return RedirectToAction("Index", new { mensaje = mensaje });
            }

            //Construimos el modelo
            var modelo = new ReferenciaEditorModelo
            {
                Convenio = convenio
            };

            modelo.Referencia.FechaSolicitudRef = DateTime.Now;

            return View("_Registrar", modelo);
        }

        public ActionResult Registrar(ReferenciaEditorModelo editor)
        {
            string mensaje = string.Empty;

            var modelo = new RegistrarReferenciaDto
            {
                Convenio = editor.Convenio,
                Mascota = editor.Mascota,
                Referencia = editor.Referencia
            };

            modelo.Referencia.ListaReferenciaConvenioServicio = editor.Referencia.ListaReferenciaConvenioServicio;

            var resultado = _registrosServicio.ReferenciaServicio.Registrar(modelo);
            if (resultado == -1)
                mensaje = MensajeMvc.MensajePeligro(Mensajes.ErrorGenerico, Util.ObtenerControllerName(Request), Util.ObtenerActionName(Request));
            else
            {
                var nroReferencia = Util.GenerarCodigo(resultado);
                mensaje = MensajeMvc.MensajeSatisfactorio(Mensajes.ReferenciaRegistrada, nroReferencia);
            }
                
           // mensaje = MensajeMvc.MensajeSatisfactorio(Mensajes.ReferenciaRegistrada, resultado);
            return RedirectToAction("Index", new { mensaje = mensaje });
        }

    }
}