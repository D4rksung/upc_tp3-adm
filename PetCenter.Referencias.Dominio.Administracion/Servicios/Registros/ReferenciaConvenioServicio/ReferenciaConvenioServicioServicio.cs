using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ReferenciaConvenioServicio;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Transversal.Mapeo;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.ReferenciaConvenioServicio
{
    public class ReferenciaConvenioServicioServicio : IReferenciaConvenioServicioServicio
    {
        #region VARIABLE

        private readonly IReferenciaConvenioServicioRepositorio _referenciaConvenioServicioRepositorio;

        #endregion

        #region CONSTRUCTOR
        public ReferenciaConvenioServicioServicio(IReferenciaConvenioServicioRepositorio referenciaConvenioServicioRepositorio)
        {
            _referenciaConvenioServicioRepositorio = referenciaConvenioServicioRepositorio;
        }
        #endregion

        public IEnumerable<ReferenciaConvenioServicioDto> Listar(int idReferencia)
        {
            return _referenciaConvenioServicioRepositorio.Listar(idReferencia).ProyectarComoLista<ReferenciaConvenioServicioDto>();
        }

    }
}