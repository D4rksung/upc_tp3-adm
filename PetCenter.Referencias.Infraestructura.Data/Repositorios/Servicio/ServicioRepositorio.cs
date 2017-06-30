using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Servicio;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Servicio;
using PetCenter.Referencias.Infraestructura.Data.Base;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using System.Collections.Generic;
using System.Linq;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Infraestructura.Data.Repositorios.Servicio
{
    public class ServicioRepositorio : Repositorio<e.GG_Servicio>, IServicioRepositorio
    {
        #region CONSTRUCTOR
        /// <summary>
        /// EquipoRepositorio
        /// </summary>
        /// <param name="unidadDeTrabajo"></param>
        public ServicioRepositorio(IModeloReferenciaUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
        #endregion

        public IEnumerable<ServicioVob> Listar()
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from b in set.GG_Servicio
                            select new ServicioVob
                            {
                                IdServicio = b.IdServicio,
                                NombreServicio = b.NombreServicio,
                                DescripcionServicio = b.DescripcionServicio,
                                TarifaBase = b.TarifaBase,
                                Estado = b.Estado
                            });
            return consulta.AsEnumerable();
        }

        public ServicioVob Buscar(int idServicio)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from b in set.GG_Servicio
                            where b.IdServicio == idServicio
                            select new ServicioVob
                            {
                                IdServicio = b.IdServicio,
                                NombreServicio = b.NombreServicio,
                                DescripcionServicio = b.DescripcionServicio,
                                TarifaBase = b.TarifaBase,
                                Estado = b.Estado
                            });
            return consulta.FirstOrDefault();
        }

    }
}