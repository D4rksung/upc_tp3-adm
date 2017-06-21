using PetCenter.Referencias.Dominio.Administracion.Base;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Transversal.Mapeo;
using System;
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

        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// CargoServicio
        /// </summary>
        /// <param name="cargoRepositorio"></param>
        public SolicitudServicio(ISolicitudRepositorio solicitudRepositorio)
        {
            _solicitudRepositorio = solicitudRepositorio;
        }

        #endregion

        public int Registrar(RegistrarSolicitudDto registro)
        {
            try
            {
                var unidadDeTrabajo = _solicitudRepositorio.UnidadDeTrabajo;
                var solicitud = registro.Solicitud.ProyectarComo<e.Solicitud>();

                using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionHelper.OptionsDefaults()))
                {
                    _solicitudRepositorio.Agregar(solicitud);

                    unidadDeTrabajo.Confirmar();

                    //Completando la transacción
                    scope.Complete();
                }
                return solicitud.IdSolicitud;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
