using PetCenter.Referencias.Dominio.Administracion.Base;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Convenio;
using PetCenter.Referencias.Dominio.Logica.Criterios.Maestros.PersonaJuridica;
using PetCenter.Referencias.Dominio.Logica.Criterios.Registros.Solicitud;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Transversal.Mapeo;
using System;
using System.Linq;
using System.Transactions;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.Criterios.Maestros.Cliente;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Convenio
{
    public class ConvenioServicio : IConvenioServicio
    {
        #region VARIABLE

        /// <summary>
        /// ICargoRepositorio
        /// </summary>
        private readonly IConvenioRepositorio _convenioRepositorio;
        private readonly ISolicitudRepositorio _solicitudRepositorio;
        private readonly IPersonaJuridicaRepositorio _personaJuridicaRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;

        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// CargoServicio
        /// </summary>
        /// <param name="cargoRepositorio"></param>
        public ConvenioServicio(IConvenioRepositorio convenioRepositorio,
            ISolicitudRepositorio solicitudRepositorio,
            IPersonaJuridicaRepositorio personaJuridicaRepositorio,
            IClienteRepositorio clienteRepositorio)
        {
            _convenioRepositorio = convenioRepositorio;
            _solicitudRepositorio = solicitudRepositorio;
            _personaJuridicaRepositorio = personaJuridicaRepositorio;
            _clienteRepositorio = clienteRepositorio;
        }

        #endregion

        public int Registrar(RegistrarConvenioDto registro)
        {
            try
            {
                var unidadDeTrabajo = _convenioRepositorio.UnidadDeTrabajo;
                var convenio = registro.Convenio.ProyectarComo<GCR_Convenio>();
                var solicitud = _solicitudRepositorio.EntidadParaEditar(new SolicitudIdCriterio(registro.Solicitud.NroSolicitud));

                convenio.ProcesaAgregar(solicitud.NroSolicitud);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionHelper.OptionsDefaults()))
                {
                    //Se crea la persona Juridica si no existiera
                    var personaJuridica = _personaJuridicaRepositorio.EntidadParaVer(new PersonaJuridicaRucCriterio(solicitud.NroRUC));
                    GCP_PersonaJuridica pj = new GCP_PersonaJuridica();
                    GCP_Cliente cl = new GCP_Cliente();

                    if (personaJuridica == null)
                    {
                        pj.RUC = solicitud.NroRUC;
                        pj.RazonSocial = solicitud.RazonSocial;
                        _personaJuridicaRepositorio.Agregar(pj);

                        //Se crea el cliente

                        cl.NombreCliente = solicitud.NombreRep;
                        cl.EmailCliente = solicitud.CorreoRep;
                        cl.AutorizaUsoDatos = "1";
                        _clienteRepositorio.Agregar(cl);
                    }
                    else
                    {
                        convenio.IdCliente = personaJuridica.IdCliente;
                    }

                    ////Se ingresa valores por default
                    //convenio.GRC_ConvenioDescuento.ToList().ForEach(x =>
                    //    {
                    //        //x.Estado = "1";                     
                    //    });

                    //convenio.GCR_ConvenioServicio.ToList().ForEach(x =>
                    //{
                    //    x.Estado = "1";
                    //});

                    ////Se modifica la solicitud a aceptado
                    //solicitud.ProcesaAceptado();
                    //_solicitudRepositorio.Modificar(solicitud);

                    ////Se crea el convenio
                    //_convenioRepositorio.Agregar(convenio);

                    unidadDeTrabajo.Confirmar();


                    //Se ingresa valores por default
                    convenio.GRC_ConvenioDescuento.ToList().ForEach(x =>
                    {
                        //x.Estado = "1";                     
                    });

                    convenio.GCR_ConvenioServicio.ToList().ForEach(x =>
                    {
                        x.Estado = "1";
                    });

                    //Se modifica la solicitud a aceptado
                    solicitud.ProcesaAceptado();
                    _solicitudRepositorio.Modificar(solicitud);

                    //Se crea el convenio
                    if (personaJuridica == null)
                        convenio.IdCliente = pj.IdCliente;
                    else
                        convenio.IdCliente = personaJuridica.IdCliente;
                    _convenioRepositorio.Agregar(convenio);

                    unidadDeTrabajo.Confirmar();

                    //Completando la transacción
                    scope.Complete();
                }
                return convenio.NroConvenio;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public ConvenioDto Buscar(int idConvenio)
        {
            return _convenioRepositorio.Buscar(idConvenio).ProyectarComo<ConvenioDto>();
        }
    }
}