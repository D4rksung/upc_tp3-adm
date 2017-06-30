using PetCenter.Referencias.Dominio.Administracion.DTOs.Comun;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Mascota;
using PetCenter.Referencias.Presentacion.Web.Models.Comun.Buscador;
using PetCenter.Referencias.Presentacion.Web.Models.Otros.Mascota;
using PetCenter.Referencias.Presentacion.Web.Resources;
using System;
using System.Web.Mvc;

namespace PetCenter.Referencias.Presentacion.Web.Controllers.Comun.Mascota
{
    public class MascotaController : BaseController
    {
        #region BANDEJA BUSCADOR
        public ActionResult BuscadorIndex(int? idCliente = null)
        {
            var modelo = new MascotaPaginadoModelo();
            modelo.Filtro.Mascota = new MascotaDto();
            modelo.Filtro.Mascota.IdCliente = !idCliente.HasValue?0:idCliente.Value;
            return PartialView("_BuscadorIndex", modelo);
        }

        public ActionResult BuscadorGrid(MascotaPaginadoModelo Mascota = null,
                                              int page = 1,
                                              string sort = "IdMascota",
                                              string sortDir = "DESC")
        {
            if (sortDir == null) sortDir = Orden.Asc;

            //Asignamos valores iniciales
            var tablaPaginado = IniciarFiltro(Mascota);

            //Construimos solicitud
            var solicitud = ConstruirSolicitud(page, sort, sortDir, tablaPaginado);

            //Invocamos al servicio            
            var respuesta = _maestrosServicio.MascotaServicio.Busqueda(solicitud);

            //Construyendo modelo
            var modelo = new BuscadorPaginadoModel<MascotaDto>(respuesta.lista, Convert.ToInt32(Paginacion.TamanioPagina10), respuesta.TotalElementos);

            //Retornando vista
            return PartialView("_BuscadorGrid", modelo);
        }

        #endregion

        #region MÉTODOS - APOYO

        /// <summary>
        /// ConstruirModeloPaginado
        /// </summary>
        /// <param name="pagina">int</param>
        /// <param name="respuesta">RespuestaMascotaDto</param>
        /// <param name="filtro">MascotaFiltroModelo</param>
        /// <returns>MascotaPaginadoModelo</returns>
        internal MascotaPaginadoModelo ConstruirModeloPaginado(int pagina, RespuestaMascotaDto respuesta, MascotaFiltroModelo filtro)
        {
            return new MascotaPaginadoModelo
            {
                Grid = new MascotaGridModelo(respuesta.lista, Convert.ToInt32(Paginacion.TamanioPagina10), respuesta.TotalElementos),
                Filtro = new MascotaFiltroModelo(filtro.Mascota)
            };
        }

        /// <summary>
        /// ConstruirSolicitud
        /// </summary>
        /// <param name="pagina">int</param>
        /// <param name="orden">string</param>
        /// <param name="ordernDir">string</param>
        /// <param name="tablaPaginado">MascotaPaginadoModelo</param>
        /// <returns>BusquedaMascotaDto</returns>
        internal BusquedaMascotaDto ConstruirSolicitud(int pagina, string orden, string ordernDir, MascotaPaginadoModelo tablaPaginado)
        {
            return new BusquedaMascotaDto
            {
                TablaFilter = tablaPaginado.Filtro.Mascota,
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
        internal MascotaPaginadoModelo IniciarFiltro(MascotaPaginadoModelo MascotaPaginado)
        {
            if (MascotaPaginado == null) MascotaPaginado = new MascotaPaginadoModelo();
            if (MascotaPaginado.Filtro.Mascota == null)
            {
                MascotaPaginado.Filtro.Mascota = new MascotaDto();
            }

            return MascotaPaginado;
        }

        #endregion
    }
}