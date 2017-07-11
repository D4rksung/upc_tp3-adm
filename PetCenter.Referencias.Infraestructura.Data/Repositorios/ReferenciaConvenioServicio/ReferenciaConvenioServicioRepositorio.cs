using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ReferenciaConvenioServicio;
using PetCenter.Referencias.Infraestructura.Data.Base;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using System.Collections.Generic;
using System.Linq;

namespace PetCenter.Referencias.Infraestructura.Data.Repositorios.ReferenciaConvenioServicio
{
    public class ReferenciaConvenioServicioRepositorio : Repositorio<GCR_SolicitudRef_Servicio>, IReferenciaConvenioServicioRepositorio
    {
        #region CONSTRUCTOR
        /// <summary>
        /// EquipoRepositorio
        /// </summary>
        /// <param name="unidadDeTrabajo"></param>
        public ReferenciaConvenioServicioRepositorio(IModeloReferenciaUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
        #endregion

        public IEnumerable<ReferenciaConvenioServicioVob> Listar(int idReferencia)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from sol in set.GCR_SolicitudRef_Servicio
                            where sol.NroSolicitudRef == idReferencia
                            select new ReferenciaConvenioServicioVob
                            {
                                NroSolicitudRef = sol.NroSolicitudRef,
                                IdServicio = sol.IdServicio,
                                NombreServicio = sol.GCR_ConvenioServicio.GG_Servicio.nombre.Replace("\r\n", string.Empty),
                                NroConvenio = sol.NroConvenio,
                                Cantidad = sol.Cantidad,
                                Observaciones = sol.Observaciones,
                                TarifaBase = sol.TarifaBase,
                                ValorBruto = sol.ValorBruto,
                                Descuento = sol.Descuento,
                                ValorNeto = sol.ValorNeto
                            });
            return consulta.AsEnumerable();
        }
    }
}
