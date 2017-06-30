using PetCenter.Referencias.Dominio.Administracion.DTOs.Comun;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Atencion;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Liquidacion;
using PetCenter.Referencias.Presentacion.Web.Controllers.Comun;
using PetCenter.Referencias.Presentacion.Web.Helpers.Extensiones;
using PetCenter.Referencias.Presentacion.Web.Helpers.Mvc;
using PetCenter.Referencias.Presentacion.Web.Models.Registros.Liquidacion;
using PetCenter.Referencias.Presentacion.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PetCenter.Referencias.Presentacion.Web.Controllers.Registros.Liquidacion
{
    public class LiquidacionController : BaseController
    {
        #region BANDEJA

        public ActionResult Index(int page = 1,
                                       string sort = "IdCliente",
                                       string sortDir = "DESC",
                                       LiquidacionPaginadoModelo tablaPaginado = null,
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
                var Atencion = ConstruirAtencion(page, sort, sortDir, tablaPaginado);

                //Invocamos al servicio            
                var respuesta = _registrosServicio.AtencionServicio.Busqueda(Atencion);

                //construimos modelo
                var model = ConstruirModeloPaginado(page, respuesta, tablaPaginado.Filtro);
                model.AsignarMensaje(mensaje);

                //if (!back) SetCache(tablaPaginado);

                ViewBag.Periodos = _maestrosServicio.GeneralServicio.PeriodoListar();
                ViewBag.Meses = _maestrosServicio.GeneralServicio.MesListar();

                return View("_Index", model);
            }
            catch (Exception)
            {
                var respuesta = new RespuestaAtencionDto();
                respuesta.lista = new List<AtencionDto>();
                respuesta.TotalElementos = 0;
                var model = ConstruirModeloPaginado(page, respuesta, tablaPaginado.Filtro);
                mensaje = MensajeMvc.MensajePeligro(Mensajes.ErrorGenerico, Util.ObtenerControllerName(Request), Util.ObtenerActionName(Request));
                model.AsignarMensaje(mensaje);
                return View("_Index", model);
            }
        }

        #endregion

        #region DETALLE
        public ActionResult Detalle(int idCliente, int idReferencia)
        {

            var atencion = _registrosServicio.AtencionServicio.BuscarPorClienteReferencia(idCliente, idReferencia);
            var detalle = _registrosServicio.AtencionServicio.ListarPorClienteReferencia(idCliente, idReferencia);
            var liquidacion = _registrosServicio.LiquidacionServicio.Calcular(detalle);

            var modelo = new LiquidacionEditorModelo
            {
                Atencion = atencion,
                ListaAtencion = detalle.ToList(),
                Liquidacion = liquidacion
            };

            return View("_Liquidar", modelo);
        }
        #endregion

        #region REGISTRAR
        [HttpPost]
        public ActionResult Registrar(LiquidacionEditorModelo editor)
        {
            string mensaje = string.Empty;

            var modelo = new RegistrarLiquidacionDto
            {
               Atencion = editor.Atencion,
               Liquidacion = editor.Liquidacion
            };

            var resultado = _registrosServicio.LiquidacionServicio.Registrar(modelo);
            if (resultado == -1)
                mensaje = MensajeMvc.MensajePeligro(Mensajes.ErrorGenerico, Util.ObtenerControllerName(Request), Util.ObtenerActionName(Request));
            else
            {                
                mensaje = MensajeMvc.MensajeSatisfactorio(Mensajes.LiquidacionRegistrada, resultado);
            }
            
            return RedirectToAction("Index", new { mensaje = mensaje });
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
        internal LiquidacionPaginadoModelo ConstruirModeloPaginado(int pagina, RespuestaAtencionDto respuesta, LiquidacionFiltroModelo filtro)
        {
            return new LiquidacionPaginadoModelo
            {
                Grid = new LiquidacionGridModelo(respuesta.lista, Convert.ToInt32(Paginacion.TamanioPagina10), respuesta.TotalElementos),
                Filtro = new LiquidacionFiltroModelo(filtro.Atencion)
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
        internal BusquedaAtencionDto ConstruirAtencion(int pagina, string orden, string ordernDir, LiquidacionPaginadoModelo tablaPaginado)
        {
            return new BusquedaAtencionDto
            {
                TablaFilter = tablaPaginado.Filtro.Atencion,
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
        internal LiquidacionPaginadoModelo IniciarFiltro(LiquidacionPaginadoModelo AtencionPaginado)
        {
            if (AtencionPaginado == null) AtencionPaginado = new LiquidacionPaginadoModelo();
            if (AtencionPaginado.Filtro.Atencion == null)
            {
                AtencionPaginado.Filtro.Atencion = new AtencionDto();
            }

            return AtencionPaginado;
        }

        #endregion
    }
}