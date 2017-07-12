using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Convenio;
using PetCenter.Referencias.Infraestructura.Data.Base;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using System.Linq;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Infraestructura.Data.Repositorios.Convenio
{
    public class ConvenioRepositorio : Repositorio<e.GCR_Convenio>, IConvenioRepositorio
    {
        #region CONSTRUCTOR
        /// <summary>
        /// EquipoRepositorio
        /// </summary>
        /// <param name="unidadDeTrabajo"></param>
        public ConvenioRepositorio(IModeloReferenciaUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
        #endregion

        public ConvenioVob Buscar(int idConvenio)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from m in set.GCR_Convenio
                            where m.NroConvenio == idConvenio
                            select new ConvenioVob
                            {
                                NroConvenio = m.NroConvenio,
                                NroSolicitud = m.NroSolicitud.Value,
                                FechaConvenio = m.FechaConvenio.Value,
                                FechaVencimiento = m.FechaVencimiento.Value,
                                NroRuc = m.GCR_Solicitud_Convenio.NroRUC,
                                RazonSocial = m.GCR_Solicitud_Convenio.RazonSocial,
                                IdCliente = m.IdCliente
                            });
            return consulta.FirstOrDefault();
        }

        public ConvenioVob BuscarPorSolicitud(int idSolicitud) {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from m in set.GCR_Convenio
                            where m.NroSolicitud == idSolicitud
                            select new ConvenioVob
                            {
                                NroConvenio = m.NroConvenio,
                                NroSolicitud = m.NroSolicitud.Value,
                                FechaConvenio = m.FechaConvenio.Value,
                                FechaVencimiento = m.FechaVencimiento.Value,
                                NroRuc = m.GCR_Solicitud_Convenio.NroRUC,
                                RazonSocial = m.GCR_Solicitud_Convenio.RazonSocial,
                                IdCliente = m.IdCliente
                            });
            return consulta.FirstOrDefault();
        }
    }
}