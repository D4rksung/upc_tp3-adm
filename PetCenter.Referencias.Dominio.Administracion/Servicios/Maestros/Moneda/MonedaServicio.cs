using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Moneda;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Moneda;
using PetCenter.Referencias.Transversal.Mapeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Moneda
{
    public class MonedaServicio : IMonedaServicio
    {
        #region VARIABLE

        /// <summary>
        /// ICargoRepositorio
        /// </summary>
        private readonly IMonedaRepositorio _monedaRepositorio;

        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// CargoServicio
        /// </summary>
        /// <param name="cargoRepositorio"></param>
        public MonedaServicio(IMonedaRepositorio monedaRepositorio)
        {
            _monedaRepositorio = monedaRepositorio;
        }

        #endregion

        public IEnumerable<MonedaDto> Listar()
        {
            return _monedaRepositorio.Listar().ProyectarComoLista<MonedaDto>();
        }
    }
}
