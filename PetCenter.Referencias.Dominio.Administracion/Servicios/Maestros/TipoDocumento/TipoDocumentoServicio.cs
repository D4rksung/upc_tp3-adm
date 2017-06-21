using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.TipoDocumento;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.TipoDocumento;
using PetCenter.Referencias.Transversal.Mapeo;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.TipoDocumento
{
    public class TipoDocumentoServicio : ITipoDocumentoServicio
    {
        #region VARIABLE

        /// <summary>
        /// ICargoRepositorio
        /// </summary>
        private readonly ITipoDocumentoRepositorio _tipoDocumentoRepositorio;

        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// CargoServicio
        /// </summary>
        /// <param name="cargoRepositorio"></param>
        public TipoDocumentoServicio(ITipoDocumentoRepositorio tipoDocumentoRepositorio)
        {
            _tipoDocumentoRepositorio = tipoDocumentoRepositorio;
        }

        #endregion

        public IEnumerable<TipoDocumentoDto> Listar()
        {
            return _tipoDocumentoRepositorio.Listar().ProyectarComoLista<TipoDocumentoDto>();
        }
    }
}
