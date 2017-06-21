using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Banco;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Banco;
using PetCenter.Referencias.Transversal.Mapeo;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Banco
{
    public class BancoServicio : IBancoServicio
    {
        #region VARIABLE

        /// <summary>
        /// ICargoRepositorio
        /// </summary>
        private readonly IBancoRepositorio _bancoRepositorio;

        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// CargoServicio
        /// </summary>
        /// <param name="cargoRepositorio"></param>
        public BancoServicio(IBancoRepositorio bancoRepositorio)
        {
            _bancoRepositorio = bancoRepositorio;
        }

        #endregion

        public IEnumerable<BancoDto> Listar()
        {
            return _bancoRepositorio.Listar().ProyectarComoLista<BancoDto>();
        }
    }
}
