using PetCenter.Referencias.Dominio.Administracion.Base;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Comun;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Atencion;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia;
using PetCenter.Referencias.Presentacion.Web.Controllers.Comun;
using PetCenter.Referencias.Presentacion.Web.Helpers.Extensiones;
using PetCenter.Referencias.Presentacion.Web.Helpers.Mvc;
using PetCenter.Referencias.Presentacion.Web.Models.Registros.Atencion;
using PetCenter.Referencias.Presentacion.Web.Resources;
using PetCenter.Referencias.Presentacion.Web.Resources.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace PetCenter.Referencias.Presentacion.Web.Controllers.Registros.Atencion
{
    public class AtencionController : BaseController
    {
        #region BANDEJA

        public ActionResult Index(int page = 1,
                                       string sort = "NroSolicitudRef",
                                       string sortDir = "DESC",
                                       AtencionPaginadoModelo tablaPaginado = null,
                                       string mensaje = null,
                                       bool back = false
                                       )
        {
            try
            {

                //if (back) tablaPaginado = GetCache(tablaPaginado);

                //Asignamos valores iniciales
                tablaPaginado = IniciarFiltro(tablaPaginado);

                //Construimos Atencion
                var referencia = ConstruirAtencion(page, sort, sortDir, tablaPaginado);

                //Invocamos al servicio            
                var respuesta = _registrosServicio.ReferenciaServicio.Busqueda(referencia);

                //construimos modelo
                var model = ConstruirModeloPaginado(page, respuesta, tablaPaginado.Filtro);
                model.AsignarMensaje(mensaje);

                //if (!back) SetCache(tablaPaginado);
                return View("_Index", model);
            }
            catch (Exception)
            {
                var respuesta = new RespuestaReferenciaDto();
                respuesta.lista = new List<ReferenciaDto>();
                respuesta.TotalElementos = 0;
                var model = ConstruirModeloPaginado(page, respuesta, tablaPaginado.Filtro);
                mensaje = MensajeMvc.MensajePeligro(Mensajes.ErrorGenerico, Util.ObtenerControllerName(Request), Util.ObtenerActionName(Request));
                model.AsignarMensaje(mensaje);
                return View("_Index", model);
            }
        }

        #endregion

        #region DETALLE
        public ActionResult Detalle(int idReferencia, string mensaje = null)
        {
            var referencia = _registrosServicio.ReferenciaServicio.Buscar(idReferencia);
            var mascota = _maestrosServicio.MascotaServicio.Buscar(referencia.IdMascota.Value);

            //Construimos el modelo
            var modelo = new AtencionEditorModelo
            {
                Referencia = referencia,
                Mascota = mascota
            };

            modelo.Referencia.NroSolicitudRefFormato = Util.GenerarCodigo(modelo.Referencia.NroSolicitudRef);

            if (!string.IsNullOrEmpty(mensaje))
                modelo.AsignarMensaje(mensaje);

            return View("_Registrar", modelo);
        }
        #endregion

        #region REGISTRAR
        //[HttpPost]
        public ActionResult Registrar(AtencionEditorModelo model)
        {            
            string mensaje = string.Empty;

            var fileStreamrs = TempData["fileStreamrs"] as HttpPostedFileBase;
            if (fileStreamrs != null)
            {
                model.Atencion.ResultadoObjeto = fileStreamrs.InputStream.ObtenerBytesOfStream();
                model.Atencion.ResultadoTitulo = fileStreamrs.FileName;
            }
            TempData["fileStreamrs"] = null;

            var editor = new RegistrarAtencionDto
            {
                Atencion = model.Atencion,
                Mascota = model.Mascota,
                Referencia = model.Referencia,
                Servicio = model.Servicio
            };

            //se inserta
            var resultado = _registrosServicio.AtencionServicio.Registrar(editor);
            if (resultado == -1)
                mensaje = MensajeMvc.MensajePeligro(Mensajes.ErrorGenerico, Util.ObtenerControllerName(Request), Util.ObtenerActionName(Request));
            else
            {
                mensaje = MensajeMvc.MensajeSatisfactorio(Mensajes.AtencionRegistrada, resultado);
            }

            var idReferencia = model.Referencia.NroSolicitudRef;

            return RedirectToAction("Detalle", new { idReferencia = idReferencia, mensaje = mensaje });
        }
        #endregion

        #region DESCARGA ARCHIVO
        [HttpGet]
        public ActionResult Descarga(int idReferencia, int idServicio, int idConvenio)
        {
            var solicitud = _registrosServicio.AtencionServicio.BuscarPorRefServConv(idReferencia, idServicio, idConvenio);
            var nombreArchivo = "";
            byte[] content = null;

            content = solicitud.ResultadoObjeto;
            nombreArchivo = solicitud.ResultadoTitulo;

            try
            {
                var extension = nombreArchivo.Split('.').Length;

                return File(content, nombreArchivo.Split('.')[extension - 1].ContentTypeExtension(), nombreArchivo);
            }
            catch (Exception ex)
            {
                //Retornando excepción en JSON
                return Json(MensajeMvc.MensajeJson(TipoNotificacionEnum.Advertencia, ex.Message));
            }
        }
        #endregion

        #region MÉTODOS - APOYO

        /// <summary>
        /// ConstruirModeloPaginado
        /// </summary>
        /// <param name="pagina">int</param>
        /// <param name="respuesta">RespuestaAtencionDto</param>
        /// <param name="filtro">AtencionFiltroModelo</param>
        /// <returns>AtencionPaginadoModelo</returns>
        internal AtencionPaginadoModelo ConstruirModeloPaginado(int pagina, RespuestaReferenciaDto respuesta, AtencionFiltroModelo filtro)
        {
            return new AtencionPaginadoModelo
            {
                Grid = new AtencionGridModelo(respuesta.lista, Convert.ToInt32(Paginacion.TamanioPagina10), respuesta.TotalElementos),
                Filtro = new AtencionFiltroModelo(filtro.Referencia)
            };
        }

        /// <summary>
        /// ConstruirAtencion
        /// </summary>
        /// <param name="pagina">int</param>
        /// <param name="orden">string</param>
        /// <param name="ordernDir">string</param>
        /// <param name="tablaPaginado">AtencionPaginadoModelo</param>
        /// <returns>BusquedaAtencionDto</returns>
        internal BusquedaReferenciaDto ConstruirAtencion(int pagina, string orden, string ordernDir, AtencionPaginadoModelo tablaPaginado)
        {
            return new BusquedaReferenciaDto
            {
                TablaFilter = tablaPaginado.Filtro.Referencia,
                CriterioPaginar = new CriterioPaginarDto
                {
                    Tamanio = Convert.ToInt32(Paginacion.TamanioPagina10),
                    Pagina = pagina,
                    Orden = orden,
                    OrdenDir = ordernDir
                }
            };
        }

        /// <summary>
        /// IniciarFiltro
        /// </summary>
        /// <param name="tablaPaginado">TablaTablaPaginadoModelo</param>
        /// <returns></returns>
        internal AtencionPaginadoModelo IniciarFiltro(AtencionPaginadoModelo AtencionPaginado)
        {
            if (AtencionPaginado == null) AtencionPaginado = new AtencionPaginadoModelo();
            if (AtencionPaginado.Filtro.Referencia == null)
            {
                AtencionPaginado.Filtro.Referencia = new ReferenciaDto();
                AtencionPaginado.Filtro.Referencia.FechaSolicitudInicio = DateTime.Now.AddDays(-30);
                AtencionPaginado.Filtro.Referencia.FechaSolicitudFin = DateTime.Now;
            }
            else
            {
                if (AtencionPaginado.Filtro.Referencia.FechaSolicitudInicio.ToShortDateString() == "1/01/0001")
                {
                    AtencionPaginado.Filtro.Referencia.FechaSolicitudInicio = DateTime.Now;
                }

                if (AtencionPaginado.Filtro.Referencia.FechaSolicitudFin.ToShortDateString() == "1/01/0001")
                {
                    AtencionPaginado.Filtro.Referencia.FechaSolicitudFin = DateTime.Now;
                }
            }

            return AtencionPaginado;
        }

        #endregion

        #region JSONRESULT
        public JsonResult ObtenerAtencion(int idReferencia, int idServicio, int idConvenio)
        {
            var resultado = _registrosServicio.AtencionServicio.BuscarPorRefServConv(idReferencia, idServicio, idConvenio);
            if (resultado == null) resultado = new AtencionDto();
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        #endregion  
    }
}