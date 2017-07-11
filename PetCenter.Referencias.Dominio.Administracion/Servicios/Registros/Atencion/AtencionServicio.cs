using PetCenter.Referencias.Dominio.Administracion.Base;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Atencion;
using PetCenter.Referencias.Dominio.Logica.Criterios.Registros.Atencion;
using PetCenter.Referencias.Dominio.Logica.Criterios.Registros.ReferenciaConvenioServicio;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Dominio.Logica.VOBs.General;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Atencion;
using PetCenter.Referencias.Transversal.Mapeo;
using PetCenter.Referencias.Transversal.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Atencion
{
    public class AtencionServicio : IAtencionServicio
    {
        #region VARIABLE

        private readonly IAtencionRepositorio _atencionRepositorio;
        private readonly IReferenciaConvenioServicioRepositorio _referenciaConvenioRepositorio;

        #endregion

        #region CONSTRUCTOR
        public AtencionServicio(IAtencionRepositorio atencionRepositorio,
            IReferenciaConvenioServicioRepositorio referenciaConvenioServicioRepositorio)
        {
            _atencionRepositorio = atencionRepositorio;
            _referenciaConvenioRepositorio = referenciaConvenioServicioRepositorio;
        }
        #endregion

        public RespuestaAtencionDto Busqueda(BusquedaAtencionDto solicitud)
        {
            try
            {
                var paginar = solicitud.CriterioPaginar;
                var listaPaginada = new PaginadoVob<AtencionVob>
                {
                    Elementos = new List<AtencionVob>(),
                    TotalElementos = 0
                };

                if (solicitud.TablaFilter != null)
                {
                    //Obteniendo resultado de la Busqueda
                    var entidaVob = solicitud.TablaFilter.ProyectarComo<AtencionVob>();
                    var criterio = new AtencionBuscadorCriterio(entidaVob);
                    var pagina = solicitud.CriterioPaginar.Pagina;
                    var tamanio = solicitud.CriterioPaginar.Tamanio;
                    var orden = solicitud.CriterioPaginar.Orden;
                    var ordenDir = solicitud.CriterioPaginar.OrdenDir;
                    listaPaginada = _atencionRepositorio.Paginado(criterio, pagina, tamanio, orden, ordenDir);
                }

                //Obtenemos el resultado
                var resultado = new RespuestaAtencionDto
                {
                    lista = listaPaginada.Elementos.ProyectarComoLista<AtencionDto>(),
                    TotalElementos = listaPaginada.TotalElementos
                };

                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public AtencionDto BuscarPorClienteReferencia(int idCliente, int idReferencia)
        {
            return _atencionRepositorio.BuscarPorClienteReferencia(idCliente, idReferencia).ProyectarComo<AtencionDto>();
        }
        public AtencionDto BuscarPorRefServConv(int idReferencia, int idServicio, int idConvenio)
        {
            return _atencionRepositorio.BuscarPorRefServConv(idReferencia, idServicio, idConvenio).ProyectarComo<AtencionDto>();
        }
        public int Registrar(RegistrarAtencionDto editor)
        {
            try
            {
                var unidadDeTrabajo = _atencionRepositorio.UnidadDeTrabajo;
                var atencion = editor.Atencion.ProyectarComo<GCR_Atenciones>();
                var servicio = editor.Servicio.ProyectarComo<GG_Servicio>();
                var referencia = editor.Referencia.ProyectarComo<GCR_SolicitudRef>();
                var referenciaConvenioServicio = _referenciaConvenioRepositorio.EntidadParaVer(
                    new ReferenciaConvenioServicioIdsCriterio(referencia.NroSolicitudRef, servicio.idServicio, referencia.NroConvenio.Value));

                using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionHelper.OptionsDefaults()))
                {
                    atencion.NroSolicitudRef = referencia.NroSolicitudRef;
                    atencion.IdServicio = servicio.idServicio;
                    atencion.NroConvenio = referencia.NroConvenio;
                    atencion.Cantidad = referenciaConvenioServicio.Cantidad;
                    atencion.TarifaBase = referenciaConvenioServicio.TarifaBase;
                    atencion.ValorBruto = referenciaConvenioServicio.ValorBruto;
                    atencion.Descuento = referenciaConvenioServicio.Descuento;
                    atencion.ValorNeto = referenciaConvenioServicio.ValorNeto;
                    atencion.FechaAtencion = DateTime.Now;
                    atencion.Estado = "1";

                    _atencionRepositorio.Agregar(atencion);

                    //Confirmando
                    unidadDeTrabajo.Confirmar();

                    //Completando la transacción
                    scope.Complete();
                }
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public IEnumerable<AtencionDto> ListarPorClienteReferencia(int idCliente, int idReferencia)
        {
            return _atencionRepositorio.ListarPorClienteReferencia(idCliente, idReferencia).ProyectarComoLista<AtencionDto>();
        }
        public IEnumerable<AtencionTotalMesDto> ObtenerTotalAtencionesPorMes()
        {
            var atenciones = _atencionRepositorio.ObtenerTotalAtencionesPorMes().ProyectarComoLista<AtencionTotalMesDto>();
            atenciones.ForEach(x =>
            {
                x.NombreMes = StringExtensions.ObtenerNombreMes(x.Mes);
            });
            
            return atenciones;
        }

        public IEnumerable<ServiciosPorAtencionDto> ObtenerServiciosPorAtencion()
        {
            return _atencionRepositorio.ObtenerServiciosPorAtencion().ProyectarComoLista<ServiciosPorAtencionDto>();
        }
    }
}