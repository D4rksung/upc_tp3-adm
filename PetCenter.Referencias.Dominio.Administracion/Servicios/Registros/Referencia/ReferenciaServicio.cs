using PetCenter.Referencias.Dominio.Administracion.Base;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ReferenciaConvenioServicio;
using PetCenter.Referencias.Dominio.Logica.Criterios.Registros.Referencia;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Dominio.Logica.VOBs.General;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Referencia;
using PetCenter.Referencias.Transversal.Mapeo;
using PetCenter.Referencias.Transversal.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Referencia
{
    public class ReferenciaServicio : IReferenciaServicio
    {

        #region VARIABLE

        private readonly IReferenciaRepositorio _referenciaRepositorio;

        private readonly IReferenciaConvenioServicioRepositorio _referenciaConvenioServicioRepositorio;

        private readonly IAtencionRepositorio _atencionRepositorio;

        private readonly IContraReferenciaRepositorio _contraReferenciaRepositorio;

        #endregion

        #region CONSTRUCTOR
        public ReferenciaServicio(IReferenciaRepositorio referenciaRepositorio,
            IReferenciaConvenioServicioRepositorio referenciaConvenioServicioRepositorio,
            IAtencionRepositorio atencionRepositorio, IContraReferenciaRepositorio contraReferenciaRepositorio)
        {
            _referenciaRepositorio = referenciaRepositorio;
            _referenciaConvenioServicioRepositorio = referenciaConvenioServicioRepositorio;
            _atencionRepositorio = atencionRepositorio;
            _contraReferenciaRepositorio = contraReferenciaRepositorio;
        }
        #endregion

        public int Registrar(RegistrarReferenciaDto registro)
        {
            try
            {
                var unidadDeTrabajo = _referenciaRepositorio.UnidadDeTrabajo;
                var referencia = registro.Referencia.ProyectarComo<GCR_SolicitudRef>();

                //referencia.ProcesaAgregar(registro.Mascota.IdMascota, registro.Convenio.NroConvenio);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionHelper.OptionsDefaults()))
                {
                    referencia.NroConvenio = registro.Convenio.NroConvenio;
                    referencia.IdMascota = registro.Mascota.IdMascota;
                    referencia.Estado = "1";

                    _referenciaRepositorio.Agregar(referencia);

                    unidadDeTrabajo.Confirmar();

                    //Completando la transacción
                    scope.Complete();
                }

                return referencia.NroSolicitudRef;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public RespuestaReferenciaDto Busqueda(BusquedaReferenciaDto solicitud)
        {
            try
            {
                var paginar = solicitud.CriterioPaginar;
                var listaPaginada = new PaginadoVob<ReferenciaVob>
                {
                    Elementos = new List<ReferenciaVob>(),
                    TotalElementos = 0
                };

                if (solicitud.TablaFilter != null)
                {
                    //Obteniendo resultado de la Busqueda
                    var entidaVob = solicitud.TablaFilter.ProyectarComo<ReferenciaVob>();
                    var criterio = new ReferenciaBuscadorCriterio(entidaVob);
                    var pagina = solicitud.CriterioPaginar.Pagina;
                    var tamanio = solicitud.CriterioPaginar.Tamanio;
                    var orden = solicitud.CriterioPaginar.Orden;
                    var ordenDir = solicitud.CriterioPaginar.OrdenDir;
                    listaPaginada = _referenciaRepositorio.Paginado(criterio, pagina, tamanio, orden, ordenDir);
                }

                //Obtenemos el resultado
                var resultado = new RespuestaReferenciaDto
                {
                    lista = listaPaginada.Elementos.ProyectarComoLista<ReferenciaDto>(),
                    TotalElementos = listaPaginada.TotalElementos
                };

                resultado.lista.ToList().ForEach(x =>
                {
                    x.ContraReferida = _contraReferenciaRepositorio.BuscarPorRefencia(x.NroSolicitudRef) == null ? false : true;
                    x.NroSolicitudRefFormato = StringExtensions.GenerarCodigo(x.NroSolicitudRef);
                });

                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ReferenciaDto Buscar(int idReferencia)
        {
            var referencia = _referenciaRepositorio.Buscar(idReferencia).ProyectarComo<ReferenciaDto>();
            referencia.NroSolicitudRefFormato = StringExtensions.GenerarCodigo(referencia.NroSolicitudRef);
            referencia.ListaReferenciaConvenioServicio = _referenciaConvenioServicioRepositorio.Listar(idReferencia).ProyectarComoLista<ReferenciaConvenioServicioDto>();

            //si ya estan en la atencion se setea como true
            referencia.ListaReferenciaConvenioServicio.ToList().ForEach(x =>
            {
                x.Atendida = _atencionRepositorio.BuscarPorRefServConv(x.NroSolicitudRef, x.IdServicio, x.NroConvenio) == null ? false : true;
            });

            return referencia;
        }

        public IEnumerable<EspeciesCantidadDto> ObtenerEspecies()
        {
            return _referenciaRepositorio.ObtenerEspecies().ProyectarComoLista<EspeciesCantidadDto>();
        }

        public IEnumerable<RazasCantidadDto> ObtenerRaza(int idEspecie)
        {
            return _referenciaRepositorio.ObtenerRaza(idEspecie).ProyectarComoLista<RazasCantidadDto>();
        }
    }
}