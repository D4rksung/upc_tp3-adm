using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Servicio;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Servicio;
using PetCenter.Referencias.Transversal.Mapeo;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Servicio
{
    public class ServicioServicio : IServicioServicio
    {
        #region VARIABLE

        /// <summary>
        /// ICargoRepositorio
        /// </summary>
        private readonly IServicioRepositorio _servicioRepositorio;

        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// CargoServicio
        /// </summary>
        /// <param name="cargoRepositorio"></param>
        public ServicioServicio(IServicioRepositorio servicioRepositorio)
        {
            _servicioRepositorio = servicioRepositorio;
        }

        #endregion

        public IEnumerable<ServicioDto> Listar()
        {
            return _servicioRepositorio.Listar().ProyectarComoLista<ServicioDto>();
        }

        public ServicioDto Buscar(int idServicio)
        {
            return _servicioRepositorio.Buscar(idServicio).ProyectarComo<ServicioDto>();
        }
    }
}
