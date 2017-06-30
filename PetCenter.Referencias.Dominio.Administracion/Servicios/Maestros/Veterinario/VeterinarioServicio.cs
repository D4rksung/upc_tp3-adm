using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Veterinario;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Veterinario;
using PetCenter.Referencias.Transversal.Mapeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Veterinario
{
    public class VeterinarioServicio : IVeterinarioServicio
    {
        #region VARIABLE

        /// <summary>
        /// ICargoRepositorio
        /// </summary>
        private readonly IVeterinarioRepositorio _veterinarioRepositorio;

        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// CargoServicio
        /// </summary>
        /// <param name="cargoRepositorio"></param>
        public VeterinarioServicio(IVeterinarioRepositorio veterinarioRepositorio)
        {
            _veterinarioRepositorio = veterinarioRepositorio;
        }

        #endregion

        public IEnumerable<VeterinarioDto> Listar()
        {
            return _veterinarioRepositorio.Listar().ProyectarComoLista<VeterinarioDto>();
        }
    }
}