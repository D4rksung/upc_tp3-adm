using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ConvenioServicio;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Transversal.Mapeo;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.ConvenioServicio
{
    public class ConvenioServicioServicio : IConvenioServicioServicio
    {
        #region VARIABLE

        /// <summary>
        /// ICargoRepositorio
        /// </summary>
        private readonly IConvenioServicioRepositorio _convenioServicioRepositorio;

        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// CargoServicio
        /// </summary>
        /// <param name="cargoRepositorio"></param>
        public ConvenioServicioServicio(IConvenioServicioRepositorio convenioServicio)
        {
            _convenioServicioRepositorio = convenioServicio;
        }

        #endregion


        public IEnumerable<ConvenioServicioDto> Listar(int idConvenio)
        {
            return _convenioServicioRepositorio.Listar(idConvenio).ProyectarComoLista<ConvenioServicioDto>();
        }

        public ConvenioServicioDto Buscar(int idServicio, int idConvenio)
        {
            return _convenioServicioRepositorio.Buscar(idServicio, idConvenio).ProyectarComo<ConvenioServicioDto>();
        }

    }
}
