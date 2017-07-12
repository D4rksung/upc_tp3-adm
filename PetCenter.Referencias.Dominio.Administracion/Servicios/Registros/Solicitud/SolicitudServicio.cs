using PetCenter.Referencias.Dominio.Administracion.Base;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Convenio;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.DocumentoRechazo;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud;
using PetCenter.Referencias.Dominio.Logica.Criterios.Maestros.PersonaJuridica;
using PetCenter.Referencias.Dominio.Logica.Criterios.Registros.Solicitud;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Dominio.Logica.VOBs.General;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Solicitud;
using PetCenter.Referencias.Transversal.Mapeo;
using PetCenter.Referencias.Transversal.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Solicitud
{
    public class SolicitudServicio : ISolicitudServicio
    {
        #region VARIABLE

        /// <summary>
        /// ICargoRepositorio
        /// </summary>
        private readonly ISolicitudRepositorio _solicitudRepositorio;
        private readonly IDocumentoRechazoRepositorio _documentoRechazoRepositorio;
        private readonly IPersonaJuridicaRepositorio _personaJuridicaRepositorio;
        private readonly IConvenioRepositorio _convenioRepositorio;

        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// CargoServicio
        /// </summary>
        /// <param name="cargoRepositorio"></param>
        public SolicitudServicio(ISolicitudRepositorio solicitudRepositorio,
            IDocumentoRechazoRepositorio documentoRechazoRepositorio,
            IPersonaJuridicaRepositorio personaJuridicaRepositorio,
            IConvenioRepositorio convenioRepositorio)
        {
            _solicitudRepositorio = solicitudRepositorio;
            _documentoRechazoRepositorio = documentoRechazoRepositorio;
            _personaJuridicaRepositorio = personaJuridicaRepositorio;
            _convenioRepositorio = convenioRepositorio;
        }

        #endregion

        public int Registrar(RegistrarSolicitudDto registro)
        {
            try
            {
                var unidadDeTrabajo = _solicitudRepositorio.UnidadDeTrabajo;
                var solicitud = registro.Solicitud.ProyectarComo<e.GCR_Solicitud_Convenio>();

                solicitud.ProcesaAgregar(solicitud);

                var ruc = _personaJuridicaRepositorio.EntidadParaVer(new PersonaJuridicaRucCriterio(solicitud.NroRUC));
                if (ruc != null)
                {
                    return -2;
                }

                using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionHelper.OptionsDefaults()))
                {
                    _solicitudRepositorio.Agregar(solicitud);

                    unidadDeTrabajo.Confirmar();

                    //Completando la transacción
                    scope.Complete();
                }
                return solicitud.NroSolicitud;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Modificar(RegistrarSolicitudDto registro)
        {
            try
            {
                var unidadDeTrabajo = _solicitudRepositorio.UnidadDeTrabajo;
                var solicitud = registro.Solicitud.ProyectarComo<e.GCR_Solicitud_Convenio>();

                solicitud.ProcesaModificar(solicitud);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionHelper.OptionsDefaults()))
                {
                    _solicitudRepositorio.Modificar(solicitud);

                    unidadDeTrabajo.Confirmar();

                    //Completando la transacción
                    scope.Complete();
                }
                return solicitud.NroSolicitud;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Rechazar(RegistrarSolicitudDto registro)
        {
            try
            {
                var unidadDeTrabajo = _solicitudRepositorio.UnidadDeTrabajo;
                var solicitud = _solicitudRepositorio.EntidadParaEditar(new SolicitudIdCriterio(registro.Solicitud.NroSolicitud));
                var documentoRechazo = registro.DocumentoRechazo.ProyectarComo<e.GCR_DocumentoRechazo>();

                solicitud.ProcesaRechazado();
                documentoRechazo.ProcesaAgregar(solicitud.NroSolicitud);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionHelper.OptionsDefaults()))
                {
                    _solicitudRepositorio.Modificar(solicitud);

                    _documentoRechazoRepositorio.Agregar(documentoRechazo);

                    unidadDeTrabajo.Confirmar();

                    //Completando la transacción
                    scope.Complete();
                }
                return solicitud.NroSolicitud;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public RespuestaSolicitudDto Busqueda(BusquedaSolicitudDto solicitud)
        {
            try
            {
                var paginar = solicitud.CriterioPaginar;
                var listaPaginada = new PaginadoVob<SolicitudVob>
                {
                    Elementos = new List<SolicitudVob>(),
                    TotalElementos = 0
                };

                if (solicitud.TablaFilter != null)
                {
                    //Obteniendo resultado de la Busqueda
                    var entidaVob = solicitud.TablaFilter.ProyectarComo<SolicitudVob>();
                    var criterio = new SolicitudBuscadorCriterio(entidaVob);
                    var pagina = solicitud.CriterioPaginar.Pagina;
                    var tamanio = solicitud.CriterioPaginar.Tamanio;
                    var orden = solicitud.CriterioPaginar.Orden;
                    var ordenDir = solicitud.CriterioPaginar.OrdenDir;
                    listaPaginada = _solicitudRepositorio.Paginado(criterio, pagina, tamanio, orden, ordenDir);
                }

                //Obtenemos el resultado
                var resultado = new RespuestaSolicitudDto
                {
                    lista = listaPaginada.Elementos.ProyectarComoLista<SolicitudDto>(),
                    TotalElementos = listaPaginada.TotalElementos
                };

                resultado.lista.ToList().ForEach(x =>
                {
                    x.NroSolicitudFormato = StringExtensions.GenerarCodigo(x.NroSolicitud);
                });

                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public SolicitudDto Buscar(int idSolicitud)
        {
            try
            {
                var solicitud = _solicitudRepositorio.Buscar(idSolicitud).ProyectarComo<SolicitudDto>();
                solicitud.NroSolicitudFormato = StringExtensions.GenerarCodigo(solicitud.NroSolicitud);

                var convenio = _convenioRepositorio.BuscarPorSolicitud(solicitud.NroSolicitud).ProyectarComo<ConvenioDto>();
                if (convenio != null)
                {
                    solicitud.NroConvenio = convenio.NroConvenio;
                    solicitud.NroConvenioFormato = StringExtensions.GenerarCodigo(solicitud.NroConvenio);
                }

                var documentoRechazo = _documentoRechazoRepositorio.BuscarPorSolicitud(solicitud.NroSolicitud).ProyectarComo<DocumentoRechazoDto>();
                if (documentoRechazo != null)
                {
                    solicitud.NroDocumentoRechazo = documentoRechazo.NroDocumento;
                    solicitud.NroDocumentoRechazoFormato = StringExtensions.GenerarCodigo(solicitud.NroDocumentoRechazo);
                }

                return solicitud;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
