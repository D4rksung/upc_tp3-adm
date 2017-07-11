using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ConvenioServicio;
using PetCenter.Referencias.Infraestructura.Data.Base;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using System.Collections.Generic;
using System.Linq;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Infraestructura.Data.Repositorios.ConvenioServicio
{
    public class ConvenioServicioRepositorio : Repositorio<e.GCR_ConvenioServicio>, IConvenioServicioRepositorio
    {
        #region CONSTRUCTOR
        /// <summary>
        /// EquipoRepositorio
        /// </summary>
        /// <param name="unidadDeTrabajo"></param>
        public ConvenioServicioRepositorio(IModeloReferenciaUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
        #endregion

        public IEnumerable<ConvenioServicioVob> Listar(int idConvenio)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from m in set.GCR_ConvenioServicio
                            where m.NroConvenio == idConvenio
                            select new ConvenioServicioVob
                            {
                                IdServicio = m.IdServicio,
                                NroConvenio = m.NroConvenio,
                                TarifaBase = m.TarifaBase,
                                FactorDcto = m.FactorDcto,
                                TarifaReal = m.TarifaReal,
                                Estado = m.Estado,
                                NombreServicio = m.GG_Servicio.nombre
                            });
            return consulta.AsEnumerable();
        }

        public ConvenioServicioVob Buscar(int idServicio, int idConvenio)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from m in set.GCR_ConvenioServicio
                            where m.NroConvenio == idConvenio && m.IdServicio == idServicio
                            select new ConvenioServicioVob
                            {
                                IdServicio = m.IdServicio,
                                NroConvenio = m.NroConvenio,
                                TarifaBase = m.TarifaBase,
                                FactorDcto = m.FactorDcto,
                                TarifaReal = m.TarifaReal,
                                Estado = m.Estado,
                                NombreServicio = m.GG_Servicio.nombre
                            });
            return consulta.FirstOrDefault();
        }
    }
}
