using PetCenter.Referencias.Dominio.Administracion.DTOs.Comun;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ContraReferencia;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia;
using PetCenter.Referencias.Presentacion.Web.Controllers.Comun;
using PetCenter.Referencias.Presentacion.Web.Helpers.Extensiones;
using PetCenter.Referencias.Presentacion.Web.Helpers.Mvc;
using PetCenter.Referencias.Presentacion.Web.Models.Registros.ContraReferencia;
using PetCenter.Referencias.Presentacion.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetCenter.Referencias.Presentacion.Web.Controllers.Registros.ContraReferencia
{
    public class ContraReferenciaController : BaseController
    {

        #region BANDEJA

        public ActionResult Index(int page = 1,
                                       string sort = "NroSolicitudRef",
                                       string sortDir = "DESC",
                                       ContraReferenciaPaginadoModelo tablaPaginado = null,
                                       string mensaje = null,
                                       bool back = false
                                       )
        {
            try
            {

                //if (back) tablaPaginado = GetCache(tablaPaginado);

                //Asignamos valores iniciales
                tablaPaginado = IniciarFiltro(tablaPaginado);

                //Construimos ContraReferencia
                var referencia = ConstruirContraReferencia(page, sort, sortDir, tablaPaginado);

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
            var contraReferencia = new ContraReferenciaDto();

            //Construimos el modelo
            var modelo = new ContraReferenciaEditorModelo
            {
                Referencia = referencia,
                Mascota = mascota,
                ContraReferencia = contraReferencia
            };

            modelo.ContraReferencia.FechaCierre = DateTime.Now;
            modelo.ContraReferencia.FechaEntrega = DateTime.Now;

            if (!string.IsNullOrEmpty(mensaje))
                modelo.AsignarMensaje(mensaje);

            ViewBag.Veterinarios = _maestrosServicio.VeterinarioServicio.Listar();

            return View("_Registrar", modelo);
        }
        #endregion


        #region REGISTRAR
        [HttpPost]
        public ActionResult Registrar(ContraReferenciaEditorModelo model)
        {
            string mensaje = string.Empty;           

            var editor = new RegistrarContraReferenciaDto
            {
                ContraReferencia = model.ContraReferencia,
                Mascota = model.Mascota,
                Referencia = model.Referencia,
                Servicio = model.Servicio
            };

            //se inserta
            var resultado = _registrosServicio.ContraReferenciaServicio.Registrar(editor);
            if (resultado == -1)
                mensaje = MensajeMvc.MensajePeligro(Mensajes.ErrorGenerico, Util.ObtenerControllerName(Request), Util.ObtenerActionName(Request));
            else
            {
                mensaje = MensajeMvc.MensajeSatisfactorio(Mensajes.ContraReferenciaRegistrada, resultado);
            }

            return RedirectToAction("Index", new { mensaje = mensaje });
        }

        #endregion

        #region MOSTRAR
        public ActionResult Mostrar(int idReferencia)
        {
            var referencia = _registrosServicio.ReferenciaServicio.Buscar(idReferencia);
            var mascota = _maestrosServicio.MascotaServicio.Buscar(referencia.IdMascota.Value);
            var contraReferencia = _registrosServicio.ContraReferenciaServicio.BuscarPorRefencia(idReferencia);
            var atenciones = _registrosServicio.AtencionServicio.ListarPorClienteReferencia(mascota.IdCliente.Value, referencia.NroSolicitudRef);

            //Construimos el modelo
            var modelo = new ContraReferenciaEditorModelo
            {
                Referencia = referencia,
                Mascota = mascota,
                ContraReferencia = contraReferencia,
                ListaAtenciones = atenciones.ToList()
            };            

            return View("_Mostrar", modelo);
        }
        #endregion

        #region MÉTODOS - APOYO

        /// <summary>
        /// ConstruirModeloPaginado
        /// </summary>
        /// <param name="pagina">int</param>
        /// <param name="respuesta">RespuestaContraReferenciaDto</param>
        /// <param name="filtro">ContraReferenciaFiltroModelo</param>
        /// <returns>ContraReferenciaPaginadoModelo</returns>
        internal ContraReferenciaPaginadoModelo ConstruirModeloPaginado(int pagina, RespuestaReferenciaDto respuesta, ContraReferenciaFiltroModelo filtro)
        {
            return new ContraReferenciaPaginadoModelo
            {
                Grid = new ContraReferenciaGridModelo(respuesta.lista, Convert.ToInt32(Paginacion.TamanioPagina10), respuesta.TotalElementos),
                Filtro = new ContraReferenciaFiltroModelo(filtro.Referencia)
            };
        }

        /// <summary>
        /// ConstruirContraReferencia
        /// </summary>
        /// <param name="pagina">int</param>
        /// <param name="orden">string</param>
        /// <param name="ordernDir">string</param>
        /// <param name="tablaPaginado">ContraReferenciaPaginadoModelo</param>
        /// <returns>BusquedaContraReferenciaDto</returns>
        internal BusquedaReferenciaDto ConstruirContraReferencia(int pagina, string orden, string ordernDir, ContraReferenciaPaginadoModelo tablaPaginado)
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
        internal ContraReferenciaPaginadoModelo IniciarFiltro(ContraReferenciaPaginadoModelo ContraReferenciaPaginado)
        {
            if (ContraReferenciaPaginado == null) ContraReferenciaPaginado = new ContraReferenciaPaginadoModelo();
            if (ContraReferenciaPaginado.Filtro.Referencia == null)
            {
                ContraReferenciaPaginado.Filtro.Referencia = new ReferenciaDto();
                ContraReferenciaPaginado.Filtro.Referencia.FechaSolicitudInicio = DateTime.Now.AddDays(-30);
                ContraReferenciaPaginado.Filtro.Referencia.FechaSolicitudFin = DateTime.Now;
            }
            else
            {
                if (ContraReferenciaPaginado.Filtro.Referencia.FechaSolicitudInicio.ToShortDateString() == "1/01/0001")
                {
                    ContraReferenciaPaginado.Filtro.Referencia.FechaSolicitudInicio = DateTime.Now;
                }

                if (ContraReferenciaPaginado.Filtro.Referencia.FechaSolicitudFin.ToShortDateString() == "1/01/0001")
                {
                    ContraReferenciaPaginado.Filtro.Referencia.FechaSolicitudFin = DateTime.Now;
                }
            }

            return ContraReferenciaPaginado;
        }

        #endregion
    }
}